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
    public class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.billing_Cycle)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p=> p.Name)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Configure the relationship with Gym
            builder.HasOne(p => p.Gym)
                .WithMany(g => g.Plans)
                .HasForeignKey(p => p.GymId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
