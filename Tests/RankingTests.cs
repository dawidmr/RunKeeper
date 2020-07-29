using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ranking;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void GetSurroundingActivities_Test()
        {
            SpeedRanking ranking = new SpeedRanking();
            int counter = 1;

            List<DataEx> activities = new List<DataEx>(Enumerable
                .Range(0, 20)
                .Select(x => new DataEx() { ActivityId = counter++.ToString() })
                .ToList());

            var result = ranking.GetSurroundingActivities(activities, 10);
        }
    }
}
