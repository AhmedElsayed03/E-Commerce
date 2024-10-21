using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Image:Entity
    {
        //Properties
        public string Name { get; set; } = string.Empty;
        public long Size { get; set; }
        public string Url { get; set; } = string.Empty;

        //Foreign Key
        public Guid ProductId { get; set; }

        //Nav Properties
        public Product? Product { get; set; }

    }
}
