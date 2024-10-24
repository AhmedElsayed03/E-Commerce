using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Models.DTOs
{
    public class CartReadDto
    {
        public IEnumerable<CartItemReadDto> CartItems { get; set; } = new List<CartItemReadDto>();
        public double? TotalPrice { get; set; }
        public bool IsActive { get; set; } = false;
        public int ItemsNumber { get; set; }
    }
}
