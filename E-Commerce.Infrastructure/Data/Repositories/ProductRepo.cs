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
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductRepo(ECommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }


        public async Task<IEnumerable<Product>> GetAll(int page, int countPerPage)
        {
            var products = await _dbContext.Products
                           .OrderBy(i => i.Name)
                           .Skip((page - 1) * countPerPage)
                           .Take(countPerPage)
                           .ToListAsync();
            return products;
        }

        public async Task<int> GetCount()
        {
            var productsCount = await _dbContext.Products.CountAsync();
            return productsCount;
        }


    }
}
