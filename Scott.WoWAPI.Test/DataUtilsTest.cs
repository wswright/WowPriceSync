using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scott.WoWAPI.Test
{
    [TestClass]
    public class DataUtilsTest
    {
        [TestMethod]
        public void LongToDateTimeTest()
        {
            long lastModified = 1411441239000;
            DateTime newVal = DataUtils.LongToDateTime(lastModified);
            Assert.AreNotEqual(DateTime.MinValue, newVal);
            Assert.AreNotEqual(DateTime.MaxValue, newVal);
            Assert.AreEqual(2014, newVal.Year);
            Assert.AreEqual(23, newVal.Day);
            Assert.AreEqual(3, newVal.Hour);
            Assert.AreEqual(0, newVal.Minute);
            Assert.AreEqual(39, newVal.Second);
        }
    }
}
