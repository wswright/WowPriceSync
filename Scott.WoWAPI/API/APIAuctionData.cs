using Newtonsoft.Json;
using Scott.WoWAPI.APIModel.AuctionData;
using Scott.WoWAPI.APIModel.AuctionDataFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.API
{
    public class APIAuctionData : IWoWAPICall<AuctionDataFile>
    {
        private string URL;
        private AuctionData auc;
        public APIAuctionData(AuctionData auc)
        {
            if (auc == null || auc.files == null || auc.files.Count < 1)
                throw new ArgumentException("AuctionData", "Auction data is invalid!");
            this.auc = auc;
            URL = auc.files[0].url;
        }

        /// <summary>
        /// Constructor for manually specifying the AuctionDataFile URL
        /// </summary>
        /// <param name="URL">The AuctionDataFile URL</param>
        public APIAuctionData(string URL)
        {
            this.URL = URL;
        }

        public string GetPath(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            return this.URL;
        }

        public async Task<AuctionDataFile> GetAuthenticatedData(RegionInfo regionInfo, RealmInfo realmInfo, string APIKey)
        {
            try
            {
                await RateLimiter.WaitForRateLimit();
                string pageData = await AsyncWebHelper.GetAuthenticatedPage(GetPath(regionInfo, realmInfo), APIKey);

                //Add setting to ignore missing members. This allows us to have extra members for tracking/stats purposes
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

                AuctionDataFile aucDataFile = JsonConvert.DeserializeObject<AuctionDataFile>(pageData, jsonSerializerSettings);
                aucDataFile.lastModified = DataUtils.LongToDateTime(auc.files[0].lastModified); //set lastModified
                return aucDataFile;
            }
            catch (Exception eX)
            {
                Console.WriteLine(string.Format("Failed to Get Auction Data File! Message: {0}", eX.Message));
                return null;
            }
        }

        public async Task<AuctionDataFile> GetData(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            try
            {
                await RateLimiter.WaitForRateLimit();
                string pageData = await AsyncWebHelper.GetPage(GetPath(regionInfo, realmInfo));

                //Add setting to ignore missing members. This allows us to have extra members for tracking/stats purposes
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

                AuctionDataFile aucDataFile = JsonConvert.DeserializeObject<AuctionDataFile>(pageData, jsonSerializerSettings);
                aucDataFile.lastModified = DataUtils.LongToDateTime(auc.files[0].lastModified); //set lastModified
                return aucDataFile;
            }
            catch (Exception eX)
            {
                Console.WriteLine(string.Format("Failed to Get Auction Data File! Message: {0}", eX.Message));
                return null;
            }
        }
    }
}
