using DataAccess.RunkeeperDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new ActivitiesRepository().GetLatestEntryDate("mroczekdawid");
        }
    }
}
