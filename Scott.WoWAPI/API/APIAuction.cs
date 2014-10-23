using Newtonsoft.Json;
using Scott.WoWAPI.APIModel.AuctionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scott.WoWAPI.API
{
    /// <summary>
    /// Fetches 
    /// </summary>
    public class APIAuction : IWoWAPICall<AuctionData>
    {
        private const string BASE_URL = "/wow/auction/data";

        public string GetPath(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            return string.Format("https://{0}{1}/{2}", regionInfo.Host, BASE_URL, realmInfo.Realm);
        }

        public async Task<AuctionData> GetAuthenticatedData(RegionInfo regionInfo, RealmInfo realmInfo, string APIKey)
        {
            await RateLimiter.WaitForRateLimit();
            string pageData = await AsyncWebHelper.GetAuthenticatedPage(GetPath(regionInfo, realmInfo), APIKey);
            AuctionData aucData = JsonConvert.DeserializeObject<AuctionData>(pageData);
            return aucData;
        }

        public async Task<AuctionData> GetData(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            await RateLimiter.WaitForRateLimit();
            string pageData = await AsyncWebHelper.GetPage(GetPath(regionInfo, realmInfo));
            AuctionData aucData = JsonConvert.DeserializeObject<AuctionData>(pageData);
            return aucData;
        }
    }
}
