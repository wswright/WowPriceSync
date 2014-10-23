using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scott.WoWAPI.Test
{
    [TestClass]
    public class RealmInfoTest
    {
        [TestMethod]
        public void RealmInfoTest1()
        {
            RealmInfo rInfo = new RealmInfo();
            rInfo.Realm = "Fenris";
            Assert.AreEqual("Fenris", rInfo.Realm);
        }
    }
}
