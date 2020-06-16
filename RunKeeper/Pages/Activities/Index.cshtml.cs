using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.RunkeeperDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RunKeeper.DataScaffolded;
using RunKeeper.Model;

namespace RunKeeper.Pages.Activities
{
    public class IndexModel : PageModel
    {
        private readonly RunKeeper.DataScaffolded.RunKeeperContext _context;
        private const string LinkPattern = "https://runkeeper.com/user/{0}/activity/{1}";

        public IndexModel(RunKeeper.DataScaffolded.RunKeeperContext context)
        {
            _context = context;
        }

        public List<DataEx> DataEx { get;set; }

        public async Task OnGetAsync()
        {
            var dataFromDb = new DataDBConnector().GetData("mroczekdawid").Where(x => x.Type == "Running").OrderByDescending(x => x.ActivityDateTime);

            DataEx.AddRange(dataFromDb.Select(x => new DataEx(x)));

            foreach (var d in DataEx)
            {
                d.Link = string.Format(LinkPattern, d.Username, d.ActivityId);
            }
        }
    }
}
