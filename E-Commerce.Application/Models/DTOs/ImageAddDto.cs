using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Models.DTOs
{
    public class ImageAddDto
    {
        public string Name { get; set; } = string.Empty;
        //public long Size { get; set; }
        public string Url { get; set; } = string.Empty;
        public Guid ProductId { get; set; }
    }
}
