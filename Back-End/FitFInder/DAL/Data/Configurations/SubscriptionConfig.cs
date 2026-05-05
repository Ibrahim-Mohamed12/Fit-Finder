using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configurations
{
    public class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.StartDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(s => s.EndDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(s => s.SubscriptionStatus)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(s => s.PaymentStatus)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(s => s.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Paid_at)
                .IsRequired()
                .HasColumnType("datetime");

            // Relationships

            builder.HasOne(s => s.Plan)
                .WithMany(p => p.Subscriptions)
                .HasForeignKey(s => s.PlanId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Gym)
                .WithMany(g => g.Subscriptions)
                .HasForeignKey(s => s.GymId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Offer)
                .WithMany(o => o.Subscriptions)
                .HasForeignKey(s => s.OfferId)
                .OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
