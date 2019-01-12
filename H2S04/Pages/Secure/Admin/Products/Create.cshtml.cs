using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using H2S04.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace H2S04.Pages.Secure.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly H2S04.Data.BaseContext _context;

        public CreateModel(H2S04.Data.BaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Categories = _context.Category.ToList();

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IList<Category> Categories { get; set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }
             
        public IEnumerable<SelectListItem> CategoryItems
        {
            get { return new SelectList(Categories,"Id","Name"); }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            if (SelectedCategoryId != 0)
            {
                if(Product.ProductCategory == null)
                {
                    Product.ProductCategory = new List<ProductCategory>();
                }

                var vp = new ProductCategory { CategoryId = SelectedCategoryId };
                Product.ProductCategory.Add(vp);
             }
             

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}