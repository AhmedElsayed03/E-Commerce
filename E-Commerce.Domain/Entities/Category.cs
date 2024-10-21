using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Category:Entity
    {
        public string Name { get; set; } = string.Empty;

        //Nav Properties
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
