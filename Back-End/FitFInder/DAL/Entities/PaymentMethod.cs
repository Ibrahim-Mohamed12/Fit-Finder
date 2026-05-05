using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PaymentMethod  : BaseEntity
    {
        public string CardNumber { get; set; } = null!;

        public CardType CardType { get; set; }

        // Relationships
        public string SubscriptionId { get; set; } = null!;
        public Subscription Subscription { get; set; }

    }
}
