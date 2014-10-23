using Scott.WoWAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWPriceSyncUI
{
    public class ImageCache
    {
        Dictionary<string, ImageEntry> Images;
        int curImageID = 0;
        private static ImageConverter imgConverter = new ImageConverter();

        private struct ImageEntry
        {
            public int id;
            public Bitmap img;

            public ImageEntry(int id, Bitmap img)
            {
                this.id = id;
                this.img = img;
            }
        }

        public ImageCache()
        {
            Images = new Dictionary<string, ImageEntry>();
        }

        public async Task PreloadImages()
        {
            StopWatch sWatch = new StopWatch();
            sWatch.Start();

            DBManager _dbMan = new DBManager();
            _dbMan.Warmup();

            sWatch.Lap("DB Warmup");

            Logger.Log("Preloading icons from DB...", Logger.Level.Info);
            int count = Images.Count();
            string qry = "SELECT icon, image FROM IconData";
            DataTable data = await (_dbMan as IDBLayer).ExecuteQuery(new SqlCommand(qry));
            sWatch.Lap("Query complete");
            foreach (DataRow dr in data.Rows)
            {
                string icon = (string)dr["icon"];

                //if (Images.ContainsKey(icon))
                //{
                //    continue;
                //}

                byte[] bytes = (byte[])dr["image"];
                Bitmap bMap = ByteToBitmap(bytes);
                Images.Add(icon, new ImageEntry(curImageID++, bMap));
            }
            sWatch.Stop();
            sWatch.LogLaps("PreloadImages");
            Logger.Log(string.Format("Preloaded {0} icons in {1}ms!", Images.Count() - count, sWatch.Elapsed.TotalMilliseconds), Logger.Level.Info);
        }

        public async Task SaveImagesToDatabase()
        {
            DBManager _dbMan = new DBManager();
            _dbMan.Warmup();

            Logger.Log("Starting Icon-DB Sync...", Logger.Level.Info);
            List<string> savedIcons = await GetSavedIcons(_dbMan);
            Logger.Log(string.Format("Icons in DB: {0}", savedIcons.Count()), Logger.Level.Info);
            foreach (KeyValuePair<string, ImageEntry> kvp in Images)
            {
                if (!savedIcons.Contains(kvp.Key))
                {
                    bool success = await SaveIcon(kvp.Key, kvp.Value, _dbMan);
                    if (success)
                        savedIcons.Add(kvp.Key);//prevent trying to save this icon again since icons are reused
                }
            }
            Logger.Log("Finished Icon-DB Sync!", Logger.Level.Info);
        }

        private async Task<bool> SaveIcon(string iconName, ImageEntry imageEntry, DBManager dbMan)
        {
            if (dbMan == null)
            {
                dbMan = new DBManager();
                dbMan.Warmup();
            }

            string qry = "INSERT INTO IconData (icon, image) VALUES (@icon, @image)";
            byte[] bytes = ImageToByte(imageEntry.img);
            SqlParameter[] sParams = new SqlParameter[2];
            sParams[0] = new SqlParameter("@icon", iconName);
            sParams[1] = new SqlParameter("@image", bytes) { SqlDbType = SqlDbType.VarBinary };
            SqlCommand cmd = new SqlCommand(qry);
            cmd.Parameters.AddRange(sParams);
            bool success = await (dbMan as IDBLayer).ExecuteNonQuery(cmd, true);
            string successMsg = "Successfully saved icon";
            string failureMsg = "Failed to save icon";
            Logger.Log(string.Format("{0} - {1}!", success ? successMsg : failureMsg, iconName), 
                        success ? Logger.Level.Info : Logger.Level.Error);
            return success;
        }

        public static Bitmap ByteToBitmap(byte[] bytes)
        {
            //return new Bitmap((Image)imgConverter.ConvertFrom(bytes));
            return (Bitmap)Bitmap.FromStream(new MemoryStream(bytes));
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public async Task<List<string>> GetSavedIcons(DBManager dbMan)
        {
            if (dbMan == null)
            {
                dbMan = new DBManager();
                dbMan.Warmup();
            }

            string qry = "SELECT icon FROM IconData";
            DataTable data = await (dbMan as IDBLayer).ExecuteQuery(new SqlCommand(qry));
            List<string> savedIcons = new List<string>();
            foreach (DataRow dr in data.Rows)
                savedIcons.Add((string)dr[0]);
            return savedIcons;
        }

        public ImageList GetImageList()
        {
            ImageList imgList = new ImageList();
            foreach(KeyValuePair<string, ImageEntry> kvp in Images)
            {
                imgList.Images.Add(kvp.Key, kvp.Value.img);
            }
            return imgList;
        }

        

        /// <summary>
        /// Gets an image corresponding to the given image name, if it is loaded or can be loaded.
        /// </summary>
        /// <param name="imageName">The name of the image to retrieve.</param>
        /// <returns>Returns a bitmap if successful, otherwise returns null.</returns>
        public Bitmap GetImage(string imageName)
        {
            if (Images.ContainsKey(imageName))
                return Images[imageName].img;
            else
            {
                Bitmap bmp = LoadImage(imageName);
                if (bmp != null)
                {
                    Images.Add(imageName, new ImageEntry(curImageID++, bmp));
                    return bmp;
                }
                else
                    return GetImage("INV_Misc_QuestionMark");
            }
        }

        public static Bitmap GetImageSimple(string imageName)
        {
            return LoadImage(imageName);
        }

        private static Bitmap LoadImage(string imageName)
        {
            try
            {
                string filename = string.Format(@"{0}\{1}.png", SettingsManager.ImageFolder, imageName);
                using (Image img = Bitmap.FromFile(filename))
                {
                    Bitmap bmp = new Bitmap(img);
                    return bmp;
                }
            }
            catch (Exception eX)
            {
                Logger.Log(string.Format("Failed to load image '{0}'! Message: {1}", imageName, eX.Message), Logger.Level.Error);
                return null;
            }
        }
    }
}
