using System;
using H2S04.Models;
using Microsoft.EntityFrameworkCore;

namespace H2S04.Data
{
    public class BaseContext :DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
         : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=alcohol;Username=root;Password=root");
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<Category>().ToTable("category");

        }

        public BaseContext()
        {
        }
    }
}
