using System;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data.ModelConfigurations
{
    public abstract class GeneralModelConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : GeneralModel
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValueSql("getdate()").ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(x => x.CreateUser).HasMaxLength(100);
            builder.Property(x => x.LastUpdate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            builder.Property(x => x.LastUpdateUser).HasMaxLength(100);
        }

    }
}
