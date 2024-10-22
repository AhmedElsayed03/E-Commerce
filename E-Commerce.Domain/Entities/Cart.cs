using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Cart : Entity
    {
        public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
        public double TotalPrice { get; set; }
        public bool IsActive { get; set; } = true;

        //public double TotalPrice => CartItems.Sum(item => item.TotalPrice);
        //public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
