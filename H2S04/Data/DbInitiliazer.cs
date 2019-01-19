using System;
using System.Collections.Generic;
using H2S04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace H2S04.Data
{
    public class DbInitiliazer
    {
        private BaseContext _context;
        public DbInitiliazer(BaseContext context)
        {
            _context = context;
        }
        public DbInitiliazer(IServiceProvider serviceProvider)
        {
            _context = new BaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BaseContext>>());
        }
        public void Seed()
        {       
                IsDropped();
                IsCreated();
                Category category = new Category
                {
                    Id = 1,
                    Name = "Whiskey"

                };

                Category category1 = new Category
                {
                    Id = 2,
                    Name = "Vodka"

                };

            _context.Category.Add(category);
            _context.Category.Add(category1);

            Product product = new Product
                {
                    Name = "Whiskey Vafla",
                    Price = 23,
                    Description = "Russion Vodka",
                };

                Product product1 = new Product
                {
                    Name = "Russion Standard Vodka",
                    Price = 18,
                    Description = "Russion Vodka",
                };

                Product product2 = new Product
                {
                    Name = "Russion Standard Vodka",
                    Price = 18,
                    Description = "Russion Vodka",
                };

                Product product3 = new Product
                {
                    Name = "Huston",
                    Price = 128,
                    Description = "Russion Vodka",
                };

            product2.ProductCategory.Add(new ProductCategory { CategoryId = category1.Id });
            product3.ProductCategory.Add(new ProductCategory { CategoryId = category1.Id });
            product1.ProductCategory.Add(new ProductCategory { CategoryId = category1.Id });


            product.ProductCategory = new List<ProductCategory>
                {
                    new ProductCategory
                    {
                        Category = category,
                        Product = product
                    }
                };

                _context.Product.Add(product);
                _context.SaveChanges();

                _context.Product.AddRange(new Product[] {product1,product2,product3 });
                
                _context.SaveChanges();

        }
        public bool IsCreated() => _context.Database.EnsureCreated();
        public bool IsDropped() => _context.Database.EnsureDeleted();
    }
}
