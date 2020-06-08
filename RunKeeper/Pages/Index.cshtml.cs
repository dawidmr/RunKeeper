using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RunKeeper.Model;
using DataAccess.RunkeeperDB;

namespace RunKeeper.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<DataEx> data = new List<DataEx>();
        private const string LinkPattern = "https://runkeeper.com/user/{0}/activity/{1}";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var dataFromDb = new DataDBConnector().GetData("mroczekdawid");

            data.AddRange(dataFromDb.Select(x => new DataEx(x)));

            foreach(var d in data)
            {
                d.Link = string.Format(LinkPattern, d.Username, d.ActivityId);
            }
        }
    }
}
