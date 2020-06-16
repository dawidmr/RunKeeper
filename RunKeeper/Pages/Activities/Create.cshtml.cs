using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RunKeeper.DataScaffolded;
using RunKeeper.Model;

namespace RunKeeper.Pages.Activities
{
    public class CreateModel : PageModel
    {
        private readonly RunKeeper.DataScaffolded.RunKeeperContext _context;

        public CreateModel(RunKeeper.DataScaffolded.RunKeeperContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DataEx DataEx { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DataEx.Add(DataEx);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
