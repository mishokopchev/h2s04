using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using H2S04.Data;
using H2S04.Models;

using PagedList;


namespace H2S04.Pages.Secure.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly H2S04.Data.BaseContext _context;


        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages() => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(H2S04.Data.BaseContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get;set; }

        public async Task OnGetAsync()
        {
        
            var products = from s in _context.Product select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(pr => pr.Name.Contains(SearchString));
            }

            products = products.Include(p => p.ProductCategory)
                        .ThenInclude(p => p.Category);

            Count = await products.CountAsync();

            if(Count is 0)
            {
                ModelState.AddModelError(string.Empty, "No data");
            }

            var retrieved = await products.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToListAsync();
            Products = retrieved;


        }
    }
}
