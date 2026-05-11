using DAL.Entities;
using DAL.Entities.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Data.Context
{
    public class FitFinderDBContext : IdentityDbContext<ApplicationUser>
    {
        public FitFinderDBContext(DbContextOptions<FitFinderDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Offer>().HasData(
            new Offer
            {
                Id = "11111111-1111-1111-1111-111111111111",
                Name = "50% Off First Month + Free PT",
                Description = "Best value for beginners starting their fitness journey.",
                DiscountPercentage = 50,
                BillingCycle = billing_cycle.Monthly
            },
            new Offer
            {
                Id = "22222222-2222-2222-2222-222222222222",
                Name = "20% Off Annual Plan",
                Description = "Best for long-term committed fitness users.",
                DiscountPercentage = 20,
                BillingCycle = billing_cycle.Annually
            },
            new Offer
            {
                Id = "33333333-3333-3333-3333-333333333333",
                Name = "30% Off Quarterly Plan",
                Description = "Best for users who prefer a shorter commitment period.",
                DiscountPercentage = 30,
                BillingCycle = billing_cycle.Quarterly
            }
        );

            modelBuilder.Entity<Features>().HasData(
                new Features { Id = "11111111-1111-1111-1111-111111111111", Name = "Personal Training" },
                new Features { Id = "22222222-2222-2222-2222-222222222222", Name = "Group Classes" },
                new Features { Id = "33333333-3333-3333-3333-333333333333", Name = "Cardio Equipment" },
                new Features { Id = "44444444-4444-4444-4444-444444444444", Name = "Weightlifting Area" },
                new Features { Id = "55555555-5555-5555-5555-555555555555", Name = "Swimming Pool" },
                new Features { Id = "66666666-6666-6666-6666-666666666666", Name = "Locker Rooms" },
                new Features { Id = "77777777-7777-7777-7777-777777777777", Name = "Nutrition Plans" },
                new Features { Id = "88888888-8888-8888-8888-888888888888", Name = "24/7 Access" },
                new Features { Id = "99999999-9999-9999-9999-999999999999", Name = "Parking" }
            );
        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }




    }
}
