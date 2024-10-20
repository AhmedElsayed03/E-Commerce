using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
