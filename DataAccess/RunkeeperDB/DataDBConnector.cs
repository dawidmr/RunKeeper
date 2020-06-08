using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.RunkeeperDB
{
    public class DataDBConnector
    {
        public void AddData(List<Data> data)
        {
            using (var context = new DataContext())
            {
                var existingActivities = context.Data.Select(d => d.ActivityId).ToList();

                foreach(var d in data)
                {
                    if (!existingActivities.Contains(d.ActivityId))
                    {
                        context.Data.Add(d);
                    }
                }

                context.SaveChanges();
            }
        }

        public List<Data> GetData(string username)
        {
            using (var context = new DataContext())
            {
                return context.Data.Where(d => d.Username == username).ToList();
            }
        }

        public DateTime? GetLatestEntryDate(string username)
        {
            using (var context = new DataContext())
            {
                return context.Data.Where(x => x.Username == username)?.Max(x => x.ActivityDateTime);
            }
        }
    }
}
