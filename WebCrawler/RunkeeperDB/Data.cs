using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler.RunkeeperDB
{
    public class Data
    {
        public int Id { get; set; }
        public string ActivityId { get; set; }
        public float Distance { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public DateTime ElapsedTime { get; set; }
    }
}
