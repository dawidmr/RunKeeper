using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RunKeeper.DataScaffolded;
using RunKeeper.Model;

namespace RunKeeper.Pages.Activities
{
    public class DetailsModel : PageModel
    {
        private readonly RunKeeper.DataScaffolded.RunKeeperContext _context;

        public DetailsModel(RunKeeper.DataScaffolded.RunKeeperContext context)
        {
            _context = context;
        }

        public DataEx DataEx { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DataEx = await _context.DataEx.FirstOrDefaultAsync(m => m.Id == id);

            if (DataEx == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
