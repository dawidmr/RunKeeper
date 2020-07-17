using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ranking;

namespace Tests
{
    [TestClass]
    public class RankingTests
    {
        [TestMethod]
        public void GetRange()
        {
            var fabric = new RangeFabric();
            var range = fabric.GetRange(13.71, "km");

            Assert.AreEqual(10, range.Min);
            Assert.AreEqual(20, range.Max);
            Assert.AreEqual("10 - 20 km", range.Description);
        }
    }
}
