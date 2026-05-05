using DAL.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Gender Gender { get; set; }
        public string Address { get; set; } = null!;
        public string ProfileImgUrl { get; set; } = null!;

        //Relationships

        public ICollection<Gym> Gyms { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
