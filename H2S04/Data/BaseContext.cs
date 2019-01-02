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
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Models.Attribute> Attribute{ get; set; }
        public DbSet<Models.AttributeValue> AttributeValue { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<Category>().ToTable("category");

            modelBuilder.Entity<ProductCategory>()
            .HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<ProductCategory>()
            .HasOne(pr => pr.Product)
            .WithMany(p => p.ProductCategory)
            .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(c => c.Category)
                .WithMany(p => p.ProductCategory)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<ProductAttributeValue>().HasKey(t => new { t.ProductId, t.AttributeValueId });

            modelBuilder.Entity<ProductAttributeValue>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.ProductAttributes)
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductAttributeValue>()
                .HasOne(a => a.AttributeValue)
                .WithMany(a => a.ProductAttributes)
                .HasForeignKey(pr => pr.AttributeValueId);


        }

        public BaseContext()
        {
        }
    }
}
