using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    public interface IWoWAPICall<T>
    {
        /// <summary>
        /// Gets the URL path for the API call.
        /// </summary>
        /// <param name="regionInfo">The Region info for the request.</param>
        /// <param name="realmInfo">The Realm info for the request.</param>
        /// <returns></returns>
        string GetPath(RegionInfo regionInfo, RealmInfo realmInfo);

        /// <summary>
        /// Gets API data without authentication.
        /// </summary>
        /// <param name="regionInfo">The Region info for this API call.</param>
        /// <param name="realmInfo">The Realm info for this API call.</param>
        /// <returns>Returns API data of type T.</returns>
        Task<T> GetData(RegionInfo regionInfo, RealmInfo realmInfo);

        /// <summary>
        /// Gets API data with authentication.
        /// </summary>
        /// <param name="regionInfo">The Region info for this API call.</param>
        /// <param name="realmInfo">The Realm info for this API call.</param>
        /// <param name="APIKey">The battle.net developer API key for this API call.</param>
        /// <returns>Returns API data of type T.</returns>
        Task<T> GetAuthenticatedData(RegionInfo regionInfo, RealmInfo realmInfo, string APIKey);
    }
}
