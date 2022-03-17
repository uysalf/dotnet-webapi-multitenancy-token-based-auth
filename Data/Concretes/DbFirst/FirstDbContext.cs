using System;
using Data.Abstracts;
using Data.ModelConfigurations;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Concretes
{
    public class FirstDbContext :  IdentityDbContext<CustomUser, IdentityRole, string>
    {
        public FirstDbContext(DbContextOptions<FirstDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new UserRefreshTokenConfiguration());
            //builder.ApplyConfigurationsFromAssembly(GetType().Assembly);//IEntityTypeConfiguration referans alan sınıflara göre Configure eder.

            builder.SeedFirstDb();
            base.OnModelCreating(builder);
        }
    }
}
