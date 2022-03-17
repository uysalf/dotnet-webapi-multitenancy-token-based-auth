using System;
using Data.Abstracts;
using Data.ModelConfigurations;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Concretes
{
    public class SecondDbContext: DbContext
    {
        public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);//IEntityTypeConfiguration referans alan sınıflara göre Configure eder.

            modelBuilder.SeedSecondDb();
            base.OnModelCreating(modelBuilder);

        }
    }


}
