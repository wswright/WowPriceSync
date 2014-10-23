using System;
using Scott.WoWAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.WoWAPI.API;
using Scott.WoWAPI.APIModel.AuctionData;
using Scott.WoWAPI.APIModel.AuctionDataFile;

namespace Scott.WoWAPI.Test
{
    [TestClass]
    public class AuctionDataTest
    {
        string testAPIKey = "YOUR_API_KEY_HERE";

        [TestMethod]
        public void TestAuctionData()
        {
            RealmInfo realmInfo = new RealmInfo();
            realmInfo.Realm = "Fenris";

            RegionInfo regionInfo = new RegionInfo(RegionInfo.Region.US, RegionInfo.Locale.en_US);

            APIAuction auc = new APIAuction();
            AuctionData aucData = auc.GetData(regionInfo, realmInfo).Result;
            Assert.IsNotNull(aucData);      
        }

        [TestMethod]
        public void TestAuthenticatedAuctionData()
        {
            RealmInfo realmInfo = new RealmInfo();
            realmInfo.Realm = "Fenris";

            RegionInfo regionInfo = new RegionInfo(RegionInfo.Region.US, RegionInfo.Locale.en_US);

            APIAuction auc = new APIAuction();
            AuctionData aucData = auc.GetAuthenticatedData(regionInfo, realmInfo, testAPIKey).Result;
            Assert.IsNotNull(aucData);
        }



        [TestMethod]
        public void TestAuctionDataFile()
        {
            RealmInfo realmInfo = new RealmInfo();
            realmInfo.Realm = "Fenris";

            RegionInfo regionInfo = new RegionInfo(RegionInfo.Region.US, RegionInfo.Locale.en_US);

            APIAuction auc = new APIAuction();
            AuctionData aucData = auc.GetAuthenticatedData(regionInfo, realmInfo, testAPIKey).Result;
            Assert.IsNotNull(aucData);

            APIAuctionData apiData = new APIAuctionData(aucData);
            AuctionDataFile aucDataFile = apiData.GetData(regionInfo, realmInfo).Result;
            Assert.IsNotNull(aucDataFile);
        }
    }
}
