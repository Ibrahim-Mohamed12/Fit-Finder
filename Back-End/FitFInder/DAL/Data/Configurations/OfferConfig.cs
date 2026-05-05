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
    public class OfferConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.BillingCycle)
                .IsRequired()
                .HasConversion<string>(); // Store enum as string

            builder.Property(o => o.DiscountPercentage)
                .IsRequired()
                .HasPrecision(5, 2); // e.g., 99.99%

        }
    }
}
