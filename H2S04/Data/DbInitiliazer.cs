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

                Category whiskey = new Category
                {
                    Id = 1,
                    Name = "Whiskey"

                };

                Category vodka = new Category
                {
                    Id = 2,
                    Name = "Vodka"

                };

                Category rom = new Category
                {
                    Id = 3,
                    Name = "Rom"

                };

            _context.Category.Add(whiskey);
            _context.Category.Add(vodka);
            _context.Category.Add(rom);

            _context.SaveChanges();

            Product jack = new Product
                {
                    Name = "Jack Daniels",
                    Price = 23,
                    Description = "American Whiskey",
                    Image="jack-daniels.jpeg"
                };

            Product savoy = new Product
            {
                Name = "Savoy Vodka",
                Price = 18,
                Description = "Russion Vodka",
                Image = "savoy-vodka.jpeg"
                };

                Product romAlco = new Product
                {
                    Name = "Captain Morgan",
                    Price = 9,
                    Description = "Rom",
                    Image = "captain-morgan.jpg"
                };

                Product roe = new Product
                {
                    Name = "Roe Coe Whiskey",
                    Price = 128,
                    Description = "Whiskey Expensive",
                    Image = "roe-coe.jpg"
                };

                jack.ProductCategory.Add(new ProductCategory { CategoryId = whiskey.Id });

                savoy.ProductCategory.Add(new ProductCategory { CategoryId = vodka.Id });
                romAlco.ProductCategory.Add(new ProductCategory { CategoryId = rom.Id });
                roe.ProductCategory.Add(new ProductCategory { CategoryId = whiskey.Id });

                _context.Product.AddRange(new Product[] {romAlco,jack,savoy,roe});
                
                _context.SaveChanges();

        }
        public bool IsCreated() => _context.Database.EnsureCreated();
        public bool IsDropped() => _context.Database.EnsureDeleted();
    }
}
