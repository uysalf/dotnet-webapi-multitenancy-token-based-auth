using System;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data.ModelConfigurations
{
    public class UserRefreshTokenConfiguration :GeneralModelConfiguration<UserRefreshToken>, IEntityTypeConfiguration<UserRefreshToken>
    {

        public override void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.Property(x => x.Expiration).HasColumnType("datetime");
            builder.Property(x => x.UserId).HasMaxLength(450);
            builder.Property(x => x.Code).HasMaxLength(200);
            base.Configure(builder);
        }
    }
}
