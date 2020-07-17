using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.RunkeeperDB
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        public void AddData(List<Data> data)
        {
            using (var context = new DataContext())
            {
                var existingActivities = context.Data.Select(d => d.ActivityId).ToList();

                foreach (var d in data)
                {
                    if (!existingActivities.Contains(d.ActivityId))
                    {
                        context.Data.Add(d);
                    }
                }

                context.SaveChanges();
            }
        }

        public Data GetActivity(string activityId)
        {
            using (var context = new DataContext())
            {
                return context.Data.FirstOrDefault(d => d.ActivityId == activityId);
            }
        }

        public DataEx GetActivityEx(string activityId)
        {
            using (var context = new DataContext())
            {
                var activity = context.Data.FirstOrDefault(d => d.ActivityId == activityId);

                return new DataEx(activity);
            }
        }

        public List<Data> GetActivities(string username)
        {
            using (var context = new DataContext())
            {
                return context.Data.Where(d => d.Username == username).ToList();
            }
        }

        public List<DataEx> GetActivitiesEx(string username)
        {
            using (var context = new DataContext())
            {
                List<DataEx> dataEx = new List<DataEx>();

                var dataFromDb = context.Data.Where(d => d.Username == username).ToList();

                dataEx.AddRange(dataFromDb.Select(x => new DataEx(x)));

                return dataEx;
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
