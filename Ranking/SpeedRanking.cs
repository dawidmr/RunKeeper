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

            ranking.orderedActivitiesInRangeIds = activitiesInRange.Select(a => a.ActivityId).ToList();
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

        private TimeSpan GetBestDifference(DataEx activity, DataEx best)
        {
            var paceInSeconds = (int)(activity.ElapsedTime.TotalSeconds / activity.Distance);
            var bestPaceInSeconds = (int)(best.ElapsedTime.TotalSeconds / best.Distance);

            var paceDifference = TimeSpan.FromSeconds(paceInSeconds - bestPaceInSeconds);

            return paceDifference;
        }

        public List<DataEx> GetSurroundingActivities(List<DataEx> activitiesInRange, int acitivityPosition, int count = 11)
        {
            if (count >= activitiesInRange.Count)
            {
                return activitiesInRange;
            }

            var sideCount = count / 2;

            if (acitivityPosition > sideCount && acitivityPosition + sideCount < activitiesInRange.Count)
            {
                return activitiesInRange
                    .Skip(acitivityPosition - sideCount - 1)
                    .Take(count)
                    .ToList();
            }
            else if (acitivityPosition <= sideCount)
            {
                return activitiesInRange
                    .Take(count)
                    .ToList();
                    
            }
            else
            {
                int rightDiff = acitivityPosition + sideCount - activitiesInRange.Count;

                return activitiesInRange
                    .Skip(acitivityPosition - 1 - sideCount - rightDiff)
                    .Take(count)
                    .ToList();
            }
        }
    }
}
