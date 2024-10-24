﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Models.DTOs
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
