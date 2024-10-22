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
    public class CartRepo : GenericRepo<Cart>, ICartRepo
    {
        private readonly ECommerceDbContext _dbContext;

        public CartRepo(ECommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Cart?> GetCartWithItems(Guid cartId)
        {
            var cart = await _dbContext.Set<Cart>()
                                   .Include(p => p.CartItems)
                                   .FirstOrDefaultAsync(p => p.Id == cartId);

            return cart;
        }
    }
}
