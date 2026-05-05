using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Offer : BaseEntity
    {
        public string Description { get; set; } = null!;
        public decimal DiscountPercentage { get; set; }

        public billing_cycle BillingCycle { get; set; }

        // Relationship with Subscription

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
