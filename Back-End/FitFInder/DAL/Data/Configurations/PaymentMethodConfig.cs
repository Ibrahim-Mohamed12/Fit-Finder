using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configurations
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pm => pm.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(pm => pm.CardType)
                .IsRequired()
                .HasConversion<string>();

            // Configure the relationship with Subscription
            builder.HasOne(pm => pm.Subscription)
                .WithOne(s => s.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
