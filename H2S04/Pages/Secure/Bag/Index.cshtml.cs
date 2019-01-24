using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H2S04.Data;
using H2S04.Models;
using H2S04.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace H2S04.Pages.Secure.Bag
{
    public class IndexModel : DI_BasePageModel
    {
        private readonly ProductService _productService;

        public IndexModel(BaseContext baseContext,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager,ProductService productService) : base(baseContext, authorizationService, userManager)
        {
            _productService = productService;
        }
        [BindProperty]
        public IList<Product> Products { get; set; } = new List<Product>();

        public int Count { get; set; }

        private int c = new Random().Next(0,100);

        public void OnGet()
        {
            string userId = UserManager.GetUserId(User);

            var bag = _productService.Get(userId);


            if(bag != null)
            {
                var hashSet = new HashSet<int>(bag.Products);
                Products = All(hashSet);

            }

        }
        public void Remove(Product product)
        {
            int id = product.Id;

        }

        public void OnPost(int productId)
        {

            string userId = UserManager.GetUserId(User);

            var bag = _productService.Get(userId);

            if (bag != null)
            {
                bag.Products = bag.Products.Where((arg) => arg != productId).ToList();
                _productService.Update(bag);
            }

            RedirectToPage("/Secure/Bag");

        }

        private List<Product> All(HashSet<int> productsId)
        {
            var query = BaseContext.Product.Where(pr => productsId.Contains(pr.Id)).ToList();
            Count = query.Count;
            return query;

        }


        public decimal Calculate()
        {
            decimal Sum = 0;
            foreach(var product in Products)
            {
                Sum =(Sum + product.Price);
            }
            return Sum;
        }

        public void RemoveWith(int id)
        {
            Products = Products.Where((arg) => arg.Id != id).ToList();
        }
    }
}
