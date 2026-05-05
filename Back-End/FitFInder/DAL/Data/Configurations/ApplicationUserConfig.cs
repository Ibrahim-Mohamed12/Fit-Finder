using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);

            builder.Property(u => u.PhoneNumber).HasMaxLength(20);

            builder.Property(u => u.LockoutEnabled).HasColumnType("bit")
                                                   .HasDefaultValue(0);

            builder.Property(u => u.Gender).IsRequired()
                                           .HasConversion<string>();


            builder.Property(u => u.Address).IsRequired().HasMaxLength(200);

            builder.Property(u => u.ProfileImgUrl).HasMaxLength(200);
        }
    }
}
