using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.RunkeeperDB
{
    public class Data
    {
        public int Id { get; set; }
        public string ActivityId { get; set; }
        public double Distance { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
}
