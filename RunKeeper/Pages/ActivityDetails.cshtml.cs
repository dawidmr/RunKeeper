using DataAccess;
using DataAccess.RunkeeperDB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Ranking;
using System.Collections.Generic;
using System.Linq;

namespace RunKeeper.Pages
{
    public class ActivityDetailsModel : PageModel
    {
        private IMemoryCache _cache;
        private IActivitiesRepository _dBConnector;
        public DataEx activityData;
        public RankingDTO ranking;
        private List<DataEx> allAcitvities;

        public ActivityDetailsModel(IMemoryCache cache, IActivitiesRepository dBConnector)
        {
            _cache = cache;
            _dBConnector = dBConnector;
        }

        public void OnGet(string activityId)
        {
            if (!_cache.TryGetValue(Constants.DataCacheField, out allAcitvities))
            {
                activityData = allAcitvities.FirstOrDefault(a => a.ActivityId == activityId);
            }
            else
            {
                activityData = _dBConnector.GetActivityEx(activityId);
            }

            ranking = new SpeedRanking().GetRanking(allAcitvities, activityId);
        }
    }
}