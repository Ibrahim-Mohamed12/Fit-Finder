using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Features : BaseEntity
    {

        public ICollection<Gym> Gyms { get; set; }
    }
}
