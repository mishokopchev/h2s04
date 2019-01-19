using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using H2S04.Data;
using H2S04.Models;

namespace H2S04.Pages.Secure.Cart
{
    public class DeleteModel : PageModel
    {
        private readonly H2S04.Data.BaseContext _context;

        public DeleteModel(H2S04.Data.BaseContext context)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bag = await _context.Bag.FindAsync(id);

            if (Bag != null)
            {
                _context.Bag.Remove(Bag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
