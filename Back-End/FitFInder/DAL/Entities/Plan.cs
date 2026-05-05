using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Plan : BaseEntity
    {
        public decimal Price { get; set; }

        public billing_cycle billing_Cycle { get; set; }

        public string Description { get; set; }

        // relationships

        public string GymId { get; set; }

        public Gym Gym { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
