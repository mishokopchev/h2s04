using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using H2S04.Data;
using H2S04.Models;

namespace H2S04.Pages.Secure.Cart
{
    public class EditModel : PageModel
    {
        private readonly H2S04.Data.BaseContext _context;

        public EditModel(H2S04.Data.BaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bag Bag { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bag = await _context.Bag.FirstOrDefaultAsync(m => m.Id == id);

            if (Bag == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagExists(Bag.Id))
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

        private bool BagExists(Guid id)
        {
            return _context.Bag.Any(e => e.Id == id);
        }
    }
}
