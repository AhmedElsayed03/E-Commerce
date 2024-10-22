using E_Commerce.Application.Abstractions.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.Repositories
{
    public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
    {
        private readonly ECommerceDbContext _dbContext;

        public CartItemRepo(ECommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
