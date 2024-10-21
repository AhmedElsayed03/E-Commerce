using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Models.DTOs
{
    public class CategoryWithProductsDto
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<ProductReadDto> Products { get; set; } = new List<ProductReadDto>();
    }
}
