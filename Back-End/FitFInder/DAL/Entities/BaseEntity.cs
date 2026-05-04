using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
