using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler;

namespace Tests
{
    [TestClass]
    public class WebCrawlerTests
    {
        [TestMethod]
        public void UpdateTest()
        {
            new Manager().Update("mroczekdawid");
        }
    }
}
