using Newtonsoft.Json;
using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.API
{
    public class APIRealmStatus : IWoWAPICall<RealmStatus>
    {
        private const string BASE_URL = "/wow/realm/status";

        public string GetPath(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            return string.Format("https://{0}{1}", regionInfo.Host, BASE_URL);
        }

        public async Task<RealmStatus> GetData(RegionInfo regionInfo, RealmInfo realmInfo)
        {
            await RateLimiter.WaitForRateLimit();
            string pageData = await AsyncWebHelper.GetPage(GetPath(regionInfo, realmInfo));
            RealmStatus rlmStatus = JsonConvert.DeserializeObject<RealmStatus>(pageData);
            return rlmStatus;
        }

        public async Task<RealmStatus> GetAuthenticatedData(RegionInfo regionInfo, RealmInfo realmInfo, string APIKey)
        {
            await RateLimiter.WaitForRateLimit();
            string pageData = await AsyncWebHelper.GetAuthenticatedPage(GetPath(regionInfo, realmInfo), APIKey);
            RealmStatus rlmStatus = JsonConvert.DeserializeObject<RealmStatus>(pageData);
            return rlmStatus;
        }
    }
}
