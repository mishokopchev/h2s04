using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace H2S04.Data
{
    public class UserContext : IdentityDbContext<ApplicationUser>
    {
        public UserContext(DbContextOptions<UserContext> options)
                   : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=users;Username=root;Password=root");
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}