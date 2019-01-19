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
    public class IndexModel : PageModel
    {
        private readonly H2S04.Data.BaseContext _context;

        public IndexModel(H2S04.Data.BaseContext context)
        {
            _context = context;
        }

        public IList<Bag> Bag { get; set; } = new List<Bag>();

        public async Task OnGetAsync()
        {
            Page();
        }
    }
}
