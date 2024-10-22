using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class CartItem : Entity
    {

        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }


        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        // Quantity of the product in the cart
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        //public double TotalPrice => Product!.Price * Quantity;
    }
}
