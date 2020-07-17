using DataAccess.RunkeeperDB;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DataAccess
{
    public class DataEx: Data
    {
        public string Link { get; set; }
        public TimeSpan Pace { get; set; }

        public DataEx()
        {

        }

        public DataEx(Data d)
        {
            ActivityDateTime = d.ActivityDateTime;
            ActivityId = d.ActivityId;
            Distance = d.Distance;
            ElapsedTime = d.ElapsedTime;
            Id = d.Id;
            Title = d.Title;
            Type = d.Type;
            Username = d.Username;
            Link = GenerateLink(d);
            Pace = GeneratePace(d);
        }

        private string GenerateLink(Data data)
        {
            return string.Format(Constants.LinkPattern, data.Username, data.ActivityId);
        }

        private TimeSpan GeneratePace(Data data)
        {
            return TimeSpan.FromSeconds((int)(data.ElapsedTime.TotalSeconds / data.Distance));
        }
    }
}
