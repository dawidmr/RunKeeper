using DataAccess;
using DataAccess.RunkeeperDB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunKeeper.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemoryCache _cache;
        private readonly IActivitiesRepository _dataConnector;
        public List<DataEx> activities;

        public IndexModel(ILogger<IndexModel> logger, IMemoryCache cache, IActivitiesRepository dataConnector)
        {
            _logger = logger;
            _cache = cache;
            _dataConnector = dataConnector;
        }

        public void OnGet()
        {
            if (!_cache.TryGetValue(Constants.DataCacheField, out activities))
            {
                activities = new ActivitiesRepository()
                    .GetActivitiesEx(Constants.MyLogin)
                    .Where(x => x.Type == "Running")
                    .OrderByDescending(x => x.ActivityDateTime).ToList();

                _cache.Set(Constants.DataCacheField, activities, new DateTimeOffset(DateTime.Now.AddHours(1)));
            }
        }

        public void OnPostUpdate()
        {
            new WebCrawler.Manager().Update(Constants.MyLogin);
            OnGet();
        }
    }
}
