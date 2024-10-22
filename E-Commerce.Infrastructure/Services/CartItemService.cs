using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Abstractions.UnitOfWork;
using E_Commerce.Application.Models.DTOs;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddItemToCart(Guid ProductId, Guid CartId)
        {
            CartItem item = new CartItem
            {
                Id = Guid.NewGuid(),
                ProductId = ProductId,
                CartId = CartId,
                Quantity = 1,
                TotalPrice = 1,
                CreateTime = DateTime.Now

            };
            var product = await _unitOfWork.ProductRepo.GetByIdAsync(ProductId);
            item.TotalPrice = product!.Price;

            await _unitOfWork.CartItemRepo.AddAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task PlusCount(Guid ProductId, Guid CartId)
        {
            // Find the CartItem corresponding to the given ProductId and CartId
            var cartItem = await _unitOfWork.CartItemRepo
                                            .FindAsync(item => item.ProductId == ProductId && item.CartId == CartId);

            if (cartItem != null)
            {
                // Increment the quantity by 1
                cartItem.Quantity += 1;

                var product = await _unitOfWork.ProductRepo.GetByIdAsync(ProductId);
                cartItem.TotalPrice = cartItem.Quantity * product!.Price;


                await _unitOfWork.CartItemRepo.UpdateAsync(cartItem);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("CartItem not found for the provided ProductId and CartId.");
            }
        }

        public async Task MinusCount(Guid ProductId, Guid CartId)
        {
            // Find the CartItem corresponding to the given ProductId and CartId
            var cartItem = await _unitOfWork.CartItemRepo
                                            .FindAsync(item => item.ProductId == ProductId && item.CartId == CartId);

            if (cartItem != null)
            {
                // Decrease the quantity by 1
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity -= 1;

                    // Get the product price to recalculate total price
                    var product = await _unitOfWork.ProductRepo.GetByIdAsync(ProductId);
                    cartItem.TotalPrice = cartItem.Quantity * product!.Price;

                    await _unitOfWork.CartItemRepo.UpdateAsync(cartItem);
                    await _unitOfWork.SaveChangesAsync();
                }
                else if (cartItem.Quantity == 1)
                {
                    // If quantity is 1, you may want to remove the item from the cart
                    await _unitOfWork.CartItemRepo.DeleteAsync(cartItem);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            else
            {
                throw new InvalidOperationException("CartItem not found for the provided ProductId and CartId.");
            }
        }

    }
}
