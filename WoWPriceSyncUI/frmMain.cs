using Scott.WoWAPI;
using Scott.WoWAPI.API;
using Scott.WoWAPI.APIModel;
using Scott.WoWAPI.APIModel.AuctionData;
using Scott.WoWAPI.APIModel.AuctionDataFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWPriceSyncUI
{
    public partial class frmMain : Form
    {
        static DBManager _dbMan;
        RegionInfo regionInfo;  //RegionInfo for some API Calls
        RealmInfo realmInfo;    //RealmInfo for some API Calls
        static bool realmStatus = true;
        List<int> _badItemIDs = new List<int>(); //Item IDs that could not sync.
        private const int MAX_ITEM_TRYS = 3;    //The maximum number of times that we'll try to save an item before it gets put on the ignore list
        private static bool IsDoingItemSync = false;

        public frmMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Performs an Auction House Sync. Hits Auction API to check for new data. If there is new data, this downloads, processes, and stores it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            //Setup region and realm info
            

            progressBar1.Value = 10;
            btnSync.Text = "Fetching URL";

            //Get the data file's info
            APIAuction apiAuc = new APIAuction();


            AuctionData auctionData;
            try
            {
                auctionData = await apiAuc.GetAuthenticatedData(regionInfo, realmInfo, SettingsManager.APIKey);
            }
            catch (Exception eX)
            {
                Logger.Log("Error getting auction data! Message: " + eX.Message, Logger.Level.Error);
                progressBar1.Value = 0;
                btnSync.Text = "&Sync";
                btnSync.Enabled = true;
                return;
            }

            if (auctionData == null || auctionData.files == null || auctionData.files.Count == 0)
            {
                Logger.Log("Failed to load AuctionData!", Logger.Level.Error);
                return;
            }

            if (auctionData.files[0].lastModified > SettingsManager.LastModified)
            {
                Logger.Log("Found an auction data update!", Logger.Level.Info);
            }
            else
            {
                progressBar1.Value = 100;
                btnSync.Text = "&Sync";
                btnSync.Enabled = true;
                Logger.Log("Aborting auction data update. No new data available.", Logger.Level.Info);
                return;
            }

            progressBar1.Value = 30;
            btnSync.Text = "Processing";

            //Download the data file
            APIAuctionData apiAucData = new APIAuctionData(auctionData);
            AuctionDataFile auctionDataFile = await apiAucData.GetData(regionInfo, realmInfo); //Don't use authentication for the auction data file

            progressBar1.Value = 100;
            btnSync.Text = "&Sync";
            btnSync.Enabled = true;

            if (auctionDataFile == null)
            {
                Logger.Log("Failed to load Auction Data File!", Logger.Level.Error);
                return;
            }
            else
            {
                SettingsManager.LastModified = auctionData.files[0].lastModified;
            }

            ProcessAuctionData(auctionDataFile);
        }

        private async void ProcessAuctionData(AuctionDataFile aucData)
        {
            bool success = await aucData.Save(_dbMan);
            Logger.Log(string.Format("Auction Data saved: {0}!", success));
            if (success)
            {
                //Run the duplicate remover
                if (!backgroundRemoveDuplicates.IsBusy)
                    backgroundRemoveDuplicates.RunWorkerAsync();

                //Run the item sync
                await DoItemSync();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Subscribe to log events
            Logger.OnLog += Logger_OnLog;

            //Initialize DB Manager
            _dbMan = new DBManager();
            _dbMan.Warmup();

            //Setup region/realm info
            regionInfo = new RegionInfo(RegionInfo.Region.US);
            realmInfo = new RealmInfo();
            realmInfo.Realm = "Fenris";
            backgroundRemoveDuplicates.RunWorkerAsync();
            UpdateStatistics();
        }

        private delegate void OnLogCallback(string message, Logger.Level lvl);
        private void Logger_OnLog(string message, Logger.Level lvl)
        {
            if (txtLog.InvokeRequired)
            {
                OnLogCallback cb = Logger_OnLog;
                this.BeginInvoke(cb, new object[] { message, lvl });
                return;
            }
            txtLog.AppendText(message + "\r\n");
        }

        private void timerSync_Tick(object sender, EventArgs e)
        {
            btnSync_Click(null, EventArgs.Empty);
        }

        
        private void timerItemSync_Tick(object sender, EventArgs e)
        {
            DoItemSync();
        }

        private async Task DoItemSync()
        {
            if (IsDoingItemSync)
                return;
            IsDoingItemSync = true;
            timerItemSync.Enabled = false;
            int[] badItems = GetBadItemList();
            int? nextItemID = await Item.GetNextItemID(_dbMan, badItems);
            if (nextItemID == null)
            {
                IsDoingItemSync = false;
                return;
            }

            APIItem apiItem = new APIItem(nextItemID.Value);
            Item item = await apiItem.GetAuthenticatedData(regionInfo, realmInfo, SettingsManager.APIKey);
            
            bool success = false;
            if(item != null)
                success = await item.Save(_dbMan);

            if (success)
            {
                Logger.Log(string.Format("Saved item #{0} - {1}!", item.id, item.name), Logger.Level.Info);
                _badItemIDs.RemoveAll(badItem => badItem.Equals(item.id));
            }
            else
            {
                int failureCount = (from c in _badItemIDs
                                    where c == nextItemID.Value
                                    select c).Count() + 1;
                Logger.Log(string.Format("Failed to save item #{0} ({1}/3)!", nextItemID.Value, failureCount), Logger.Level.Warning);
                _badItemIDs.Add(nextItemID.Value);
                if(failureCount >= MAX_ITEM_TRYS)
                    Logger.Log(string.Format("Putting item #{0} on the bad item list!", nextItemID.Value), Logger.Level.Warning);
            }
            IsDoingItemSync = false;
            timerItemSync.Enabled = true;
        }

        private int[] GetBadItemList()
        {

            List<int> baddies = new List<int>();
            foreach (int i in _badItemIDs.Distinct())
            {
                int count = (from c in _badItemIDs
                             where c == i
                             select c).Count();
                if (count >= MAX_ITEM_TRYS)
                    baddies.Add(i);
            }
            return baddies.ToArray();
        }

        private void btnItemSync_Click(object sender, EventArgs e)
        {
            DoItemSync();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            frmRulesManager fRulesMan = new frmRulesManager();
            fRulesMan.Show();
        }

        private async void timRealmStatus_Tick(object sender, EventArgs e)
        {
            lblRealmStatus.ForeColor = Color.Black;
            lblRealmStatus.Text = "Refreshing...";
            APIRealmStatus apiRlmStatus = new APIRealmStatus();
            RealmStatus rlmStatus;
            try
            {
                rlmStatus = await apiRlmStatus.GetAuthenticatedData(regionInfo, realmInfo, SettingsManager.APIKey);
            }
            catch (Exception eX)
            {
                Logger.Log("Failed to check realm status! Message: " + eX.Message, Logger.Level.Error);
                return;
            }

            if (rlmStatus == null || rlmStatus.realms == null)
            {
                Logger.Log("Realm status was blank!", Logger.Level.Warning);
                return;
            }

            Scott.WoWAPI.APIModel.Realm rlm = rlmStatus.realms.Single(r => r.name == "Fenris");
            if (rlm.status == true)
            {
                lblRealmStatus.Text = "Online!";
                lblRealmStatus.ForeColor = Color.Green;

                if (!realmStatus)//If the realm was previously down, but now it isn't, play an alert
                {
                    PlayAlert();
                    Logger.Log("Fenris came back online!", Logger.Level.Info);
                }

                realmStatus = true;
                timRealmStatus.Interval = 60000;
            }
            else
            {
                if (realmStatus)
                    Logger.Log("Fenris went offline!", Logger.Level.Info);
                lblRealmStatus.Text = "Offline!";
                lblRealmStatus.ForeColor = Color.Red;
                realmStatus = false;
                timRealmStatus.Interval = 2000;
            }
        }

        /// <summary>
        /// This is a simple alert to note that that realm is back up.
        /// TODO: Replace this with a wav/mp3 file that gets played.
        /// </summary>
        private void PlayAlert()
        {
            SystemSounds.Beep.Play();
            Thread.Sleep(200);
            SystemSounds.Beep.Play();
            Thread.Sleep(200);
            SystemSounds.Beep.Play();
            Thread.Sleep(200);
            SystemSounds.Beep.Play();
            Thread.Sleep(200);
            SystemSounds.Beep.Play();
        }

        private bool RemovingDuplicates = false;
        private void timRemoveDuplicateAuctions_Tick(object sender, EventArgs e)
        {
            if (!RemovingDuplicates)
            {
                Application.DoEvents();
                RemovingDuplicates = true;
                RemoveDuplicates();
            }
        }

        private void RemoveDuplicates()
        {
            StopWatch sWatch = new StopWatch();
            sWatch.Start();
            DuplicateAuctionRemover dupRemover = new DuplicateAuctionRemover();
            bool success = dupRemover.RemoveDuplicates();
            sWatch.Stop();
            if (success)
                Logger.Log(string.Format("Removed {0} duplicates successfully in {1}ms!", dupRemover.RowsToRetrieve, sWatch.Elapsed.TotalMilliseconds), Logger.Level.Info);
            else
                Logger.Log("Failed to remove duplicates!", Logger.Level.Warning);
            RemovingDuplicates = false;
        }

        private void backgroundRemoveDuplicates_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(20000);
            while (true)
            {
                StopWatch sWatch = new StopWatch();
                sWatch.Start();
                DuplicateAuctionRemover dupRemover = new DuplicateAuctionRemover();
                bool success = dupRemover.RemoveDuplicates();

                if (dupRemover.NoMoreDuplicates)
                {
                    Logger.Log("No duplicates found. Stopping duplicate remover!", Logger.Level.Info);
                    return;
                }

                sWatch.Stop();
                if (success)
                    Logger.Log(string.Format("Removed {0} duplicates successfully in {1}ms!", dupRemover.RowsToRetrieve, sWatch.Elapsed.TotalMilliseconds), Logger.Level.Info);
                else
                    Logger.Log("Failed to remove duplicates!", Logger.Level.Warning);
            }
        }

        private void statusStrip1_DoubleClick(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        private async void UpdateStatistics()
        {
            toolStripAuctionCount.Text = toolStripItemCount.Text = "-";

            string itemQry = "SELECT /*+ parallel(a) */  count(1) from ItemData a WITH (NOLOCK);";
            string auctionQry = "SELECT /*+ parallel(a) */  count(1) from AuctionData a WITH (NOLOCK);";
            int? itemCount = await _dbMan.ExecuteQuery_ScalarInt(new SqlCommand(itemQry));
            int? auctionCount = await _dbMan.ExecuteQuery_ScalarInt(new SqlCommand(auctionQry));

            if (itemCount.HasValue)
                toolStripItemCount.Text = string.Format("{0:n0}", itemCount.Value);

            if (auctionCount.HasValue)
                toolStripAuctionCount.Text = string.Format("{0:n0}", auctionCount.Value);
        }

    }
}
