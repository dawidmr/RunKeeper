using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.RunkeeperDB;

namespace RunKeeper.Model
{
    public class DataEx: Data
    {
        public string Link { get; set; }

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
        }
    }
}
