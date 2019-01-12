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
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryId { get; set; } = 0;

        public int Count { get; set; }

        public int PageSize { get; set; } = 2;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<Product> Products { get; set; }

        public IList<Category> Categories { get; set; }

        public IEnumerable<SelectListItem> CategoryItems
        {
            get
            {
            
                var ll = new List<SelectListItem>();

                ll.Add(new SelectListItem() { Text = "Please choose", Value = "0"});

                foreach (Category category in Categories)
                {
                    ll.Add(new SelectListItem() { Text = category.Name, Value = category.Id + "" });
                }

                return ll;
            }
        }


        public async Task OnGetAsync()
        {

            GetCategoriesAsync();

            var products = from s in BaseContext.Product select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(pr => pr.Name.Contains(SearchString));
            }

            if (SelectedCategoryId != 0 )
            {
                products = products.Where(pr => pr.ProductCategory.All((elem) => elem.CategoryId == SelectedCategoryId));
            }

            products.Include(p => p.ProductCategory)
                        .ThenInclude(p => p.Category);


            Count = await products.CountAsync();

            if (CheckForNoData())
            {
                Products = await products.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToListAsync();
            }
            else
            {
                Products = new List<Product>();
            }



        }

        public int TotalPages() => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        private bool CheckForNoData()
        {
            if (Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No data");
                return false;
            }

            return true;
        }

        private async Task GetCategoriesAsync()
        {
            Categories = await BaseContext.Category.ToListAsync();

        }
    }


}
