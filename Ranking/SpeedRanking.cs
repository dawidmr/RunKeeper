using DataAccess;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    public class SpeedRanking
    {
        private string unit = "km";

        public RankingDTO GetRanking(List<DataEx> allActivities, string activityId)
        {
            var ranking = new RankingDTO();

            var activity = allActivities.FirstOrDefault(a => a.ActivityId == activityId);
            ranking.range = new RangeFabric().GetRange(activity.Distance, unit);

            var activitiesInRange = GetOrderedActivitesInRange(allActivities, ranking.range);

            ranking.activitiesInRangeIds = activitiesInRange.Select(a => a.ActivityId).ToList();
            ranking.position = activitiesInRange.ToList().IndexOf(activity) + 1;
            ranking.bestDifference = GetBestDifference(activity, activitiesInRange.First());

            return ranking;
        }

        public IEnumerable<DataEx> GetOrderedActivitesInRange(List<DataEx> activities, IRange range)
        {
            return activities
                .Where(a => a.Distance >= range.Min && a.Distance <= range.Max)
                .OrderBy(a => a.Pace);
        }

        public TimeSpan GetBestDifference(DataEx activity, DataEx best)
        {
            var paceInSeconds = (int)(activity.ElapsedTime.TotalSeconds / activity.Distance);
            var bestPaceInSeconds = (int)(best.ElapsedTime.TotalSeconds / best.Distance);

            var paceDifference = TimeSpan.FromSeconds(paceInSeconds - bestPaceInSeconds);

            return paceDifference;
        }
    }
}
