﻿using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Abstractions.Repositories
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        Task <string> GetCategoryNameById (Guid categoryId);
        Task<Category?> GetCategoryWithProducts(Guid categoryId);
    }
}
