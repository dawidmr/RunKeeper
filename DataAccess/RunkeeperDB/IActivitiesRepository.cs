using System.Collections.Generic;

namespace DataAccess.RunkeeperDB
{
    public interface IActivitiesRepository
    {
        List<Data> GetActivities(string username);
        Data GetActivity(string activityId);
        DataEx GetActivityEx(string activityId);
        List<DataEx> GetActivitiesEx(string username);
    }
}