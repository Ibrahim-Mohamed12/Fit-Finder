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
    public class GymConfig : IEntityTypeConfiguration<Gym>
    {
        public void Configure(EntityTypeBuilder<Gym> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.Location)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(g => g.OpenTime)
                .IsRequired()
                .HasColumnType("time");

            builder.Property(g => g.CloseTime)
                .IsRequired()
                .HasColumnType("time");

            builder.Property(g => g.CoverImageUrl)
                .IsRequired()
                .HasMaxLength(200);

            // Configure the relationship with ApplicationUser (Owner)
            builder.HasOne(g => g.Owner)
                .WithMany()
                .HasForeignKey(g => g.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship with Features many-to-many new Table
            builder.HasMany(g => g.Features)
                .WithMany(f => f.Gyms)
                .UsingEntity(j => j.ToTable("GymFeatures"));
        }
    }
}
