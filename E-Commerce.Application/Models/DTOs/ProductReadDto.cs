using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Models.DTOs
{
    public class ProductReadDto
    {

        public string Name { get; set; } = string.Empty;
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public string Category { get; set; } = string.Empty;
        public IEnumerable<string> ImagesUrls { get; set; } = new List<string>();

    }
}
