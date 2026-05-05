using DAL.Entities.Enums;

namespace DAL.Entities
{
    public class Subscription : BaseEntity
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public SubscriptionStatus SubscriptionStatus { get; set; }

        public decimal Amount { get; set; }
        public DateTime Paid_at { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        // Relationships
        public string PlanId { get; set; } = null!;
        public Plan Plan { get; set; }

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; }


        public string GymId { get; set; } = null!;
        public Gym Gym { get; set; }
    
        public string OfferId { get; set; } = null!;
        public Offer Offer { get; set; }

        public string PaymentMethodId { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; }

    }
}
