using DataAccess;
using DataAccess.RunkeeperDB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Ranking;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace RunKeeper.Pages
{
    public class ActivityDetailsModel : PageModel
    {
        private IMemoryCache _cache;
        private IActivitiesRepository _dBConnector;
        public DataEx activityData;
        public RankingDTO ranking;
        private List<DataEx> allAcitvities;
        public string ChartData = null;

        public ActivityDetailsModel(IMemoryCache cache, IActivitiesRepository dBConnector)
        {
            _cache = cache;
            _dBConnector = dBConnector;
        }

        public void OnGet(string activityId)
        {
            int[] chartData = { 1, 2, 3, 5, 10 , 20};
            ChartData = JsonSerializer.Serialize(chartData, typeof(int[]));

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