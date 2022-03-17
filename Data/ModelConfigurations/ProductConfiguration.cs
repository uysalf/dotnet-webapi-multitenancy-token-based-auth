using System;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations
{
    public class ProductConfiguration : GeneralModelConfiguration<Product>, IEntityTypeConfiguration<Product> 
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.StockCode).HasMaxLength(200);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2");//.HasPrecision(18, 2);
            builder.Property(x => x.Description).HasMaxLength(200);
            base.Configure(builder);
        }
    }
}
