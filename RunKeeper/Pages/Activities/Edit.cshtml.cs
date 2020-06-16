using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RunKeeper.DataScaffolded;
using RunKeeper.Model;

namespace RunKeeper.Pages.Activities
{
    public class EditModel : PageModel
    {
        private readonly RunKeeper.DataScaffolded.RunKeeperContext _context;

        public EditModel(RunKeeper.DataScaffolded.RunKeeperContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DataEx).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExExists(DataEx.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DataExExists(int id)
        {
            return _context.DataEx.Any(e => e.Id == id);
        }
    }
}
