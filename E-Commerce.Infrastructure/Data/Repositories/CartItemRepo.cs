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
    public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
    {
        private readonly ECommerceDbContext _dbContext;

        public CartItemRepo(ECommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<CartItem?> FindAsync(Func<CartItem, bool> predicate)
        {
            return await Task.Run(() => _dbContext.CartItems.FirstOrDefault(predicate));
        }

        public async Task DeleteCartItemAsync(Guid cartId, Guid productId)
        {
            // Find the CartItem that matches the provided cartId and productId
            var cartItem = await _dbContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);

            // Check if the cartItem exists
            if (cartItem == null)
            {
                Console.Write("Doesn't exist");
            }

            _dbContext.CartItems.Remove(cartItem!);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

        }

    }
}
