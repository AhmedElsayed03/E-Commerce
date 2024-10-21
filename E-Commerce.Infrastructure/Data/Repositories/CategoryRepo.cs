using E_Commerce.Application.Abstractions.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.Repositories
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly ECommerceDbContext _dbContext;

        public CategoryRepo(ECommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<string> GetCategoryNameById(Guid categoryId)
        {
            var category = await _dbContext.Categories
                           .FirstOrDefaultAsync(c => c.Id == categoryId);

            return category?.Name!;
        }


        public async Task<Category?> GetCategoryWithProducts(Guid categoryId)
        {
            return await _dbContext.Set<Category>()
                                   .Include(p => p.Products)
                                   .ThenInclude(p=>p.Images)
                                   .FirstOrDefaultAsync(p => p.Id == categoryId);
        }


    }
}
