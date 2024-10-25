using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Product:Entity
    {
        //Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        //public bool IsAdded { get; set; } = false;

        //Foreign Key
        public Guid CategoryId { get; set; }

        //Nav Properties
        public IEnumerable<Image> Images { get; set; } = new List<Image>();
        public Category? Category { get; set; }

    }
}
