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

        public decimal Rating { get; set; } // This is Fuck

    }
}
