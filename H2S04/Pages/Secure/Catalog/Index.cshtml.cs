using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H2S04.Data;
using H2S04.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace H2S04.Pages.Secure.Catalog
{
    [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(BaseContext baseContext, 
        IAuthorizationService authorizationService, 
            UserManager<ApplicationUser> userManager) : base(baseContext, authorizationService, userManager)
        {

        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<Product> Products { get; set; }

        public IList<Category> Categories { get; set; }

        public int TotalPages() => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public async Task OnGetAsync()
        {

            var products = from s in BaseContext.Product select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(pr => pr.Name.Contains(SearchString));
            }

            products.Include(p => p.ProductCategory)
                        .ThenInclude(p => p.Category);


            Count = await products.CountAsync();
            Products = await products.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToListAsync();

        }
    }
}
