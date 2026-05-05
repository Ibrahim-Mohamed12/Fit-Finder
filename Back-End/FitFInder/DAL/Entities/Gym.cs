using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Gym : BaseEntity
    {
        public string Location { get; set; }= null!;

        public string Description { get; set; }= null!;

        public string CoverImageUrl { get; set; } = null!;
        
        public TimeOnly OpenTime { get; set; }

        public TimeOnly CloseTime { get; set; }

        //Feature needs Relation ship

        public string OwnerId { get; set; } = null!;
        public ApplicationUser Owner;

       public ICollection<Features> Features { get; set; }


       public ICollection<Plan> Plans { get; set; }

         public ICollection<Subscription> Subscriptions { get; set; }

    }
}
