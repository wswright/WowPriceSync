using Newtonsoft.Json;
using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.API
{
    public class APIItem : IWoWAPICall<Item>
    {
        private const string BASE_URL = "/wow/item";
        private int ItemID;

        public string GetPath(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            return string.Format("https://{0}{1}/{2}", regionInfo.Host, BASE_URL, ItemID);
        }

        public async Task<Item> GetData(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            await RateLimiter.WaitForRateLimit();
            string pageData = await AsyncWebHelper.GetPage(GetPath(regionInfo, realmInfo));

            //Add setting to ignore missing members. This allows us to have extra members for tracking/stats purposes
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

            Item aucData = JsonConvert.DeserializeObject<Item>(pageData, jsonSerializerSettings);
            return aucData;
        }

        public async Task<Item> GetAuthenticatedData(RegionInfo regionInfo, RealmInfo realmInfo, string APIKey)
        {
            await RateLimiter.WaitForRateLimit();
            string pageData = await AsyncWebHelper.GetAuthenticatedPage(GetPath(regionInfo, realmInfo), APIKey);

            //Add setting to ignore missing members. This allows us to have extra members for tracking/stats purposes
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

            Item aucData = JsonConvert.DeserializeObject<Item>(pageData, jsonSerializerSettings);
            return aucData;
        }

        public APIItem(int ItemID)
        {
            this.ItemID = ItemID;
        }
    }
}
