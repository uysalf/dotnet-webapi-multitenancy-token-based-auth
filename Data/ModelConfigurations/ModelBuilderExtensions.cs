using System;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelConfigurations
{
    public static class ModelBuilderExtensions
    {
        public static void SeedFirstDb(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(

                new Product() { Id = 1, Name = "Samsung Galaxy A02 32 GB", Price = 2434, Description = "Samsung Galaxy A02 32 GB (Samsung Türkiye Garantili)", CreateUser = "Admin", LastUpdateUser = "Admin", StockCode = "ABC" },
                new Product() { Id = 2, Name = "Samsung Galaxy A03 32 GB", Price = 3346, Description = "Samsung Galaxy A03 32 GB (Samsung Türkiye Garantili)", CreateUser = "Admin", LastUpdateUser = "Admin", StockCode = "ABC" },
                new Product() { Id = 3, Name = "Samsung Galaxy A04 32 GB", Price = 4544, Description = "Samsung Galaxy A04 32 GB (Samsung Türkiye Garantili)", CreateUser = "Admin", LastUpdateUser = "Admin", StockCode = "ABC" }
                );

            builder.Entity<IdentityRole>().HasData(
                   new IdentityRole() { Name = "Admin", NormalizedName = "Admin", ConcurrencyStamp = "1" },
                   new IdentityRole() { Name = "CustomerManeger", NormalizedName = "CustomerManeger", ConcurrencyStamp = "1" },
                   new IdentityRole() { Name = "ProductManager", NormalizedName = "ProductManager", ConcurrencyStamp = "1" }
                   );
        }

        public static void SeedSecondDb(this ModelBuilder builder)
        {


            builder.Entity<Customer>().HasData(

               new Customer() { Id = 1, FirstName = "Ahmet", LastName = "Gündüz", Email = "ahmet.gunduz@xyz.com", PhoneNumber = "123548", City = "İstanbul", CreateUser = "Admin", LastUpdateUser = "Admin" },
              new Customer() { Id = 2, FirstName = "Mustafa", LastName = "Yılmaz", Email = "mustafa.yilmaz@xyz.com", PhoneNumber = "2322323", City = "Ankara", CreateUser = "Admin", LastUpdateUser = "Admin" },
               new Customer() { Id = 3, FirstName = "Mehmet", LastName = "Güneş", Email = "mehmet.gunes@xyz.com", PhoneNumber = "2323", City = "İzmir", CreateUser = "Admin", LastUpdateUser = "Admin" }
               );


        }
    }
}
