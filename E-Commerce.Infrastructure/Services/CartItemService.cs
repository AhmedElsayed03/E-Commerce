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
            // Create a new CartItem
            CartItem item = new CartItem
            {
                Id = Guid.NewGuid(),
                ProductId = ProductId,
                CartId = CartId,
                Quantity = 1,
                CreateTime = DateTime.Now
            };

            // Retrieve the product to get its price
            var product = await _unitOfWork.ProductRepo.GetByIdAsync(ProductId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            // Set the TotalPrice for the CartItem
            item.TotalPrice = product.Price; // Assuming TotalPrice = Price of the product initially

            // Add the CartItem to the repository
            await _unitOfWork.CartItemRepo.AddAsync(item);

            // Update the cart's total price
            var cart = await _unitOfWork.CartRepo.GetByIdAsync(CartId); // Assuming you have a CartRepo to get the cart
            if (cart != null)
            {
                // Update the cart's total price
                cart.TotalPrice = (cart.TotalPrice ?? 0) + item.TotalPrice; // Increment the total price by the new item price
                if (cart.IsActive==false)
                {
                    cart.IsActive= true;
                }

                // Update the Cart in the repository
                await _unitOfWork.CartRepo.UpdateAsync(cart);
            }

            // Save changes to the database
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

                // Get the product price
                var product = await _unitOfWork.ProductRepo.GetByIdAsync(ProductId);
                cartItem.TotalPrice = cartItem.Quantity * product!.Price;

                // Update the CartItem
                await _unitOfWork.CartItemRepo.UpdateAsync(cartItem);

                // Reload the cart with its CartItems to ensure up-to-date data
                var cart = await _unitOfWork.CartRepo.GetCartWithItems(CartId); // Using a method that includes CartItems

                if (cart != null)
                {
                    // Recalculate the total price of the cart
                    cart.TotalPrice = cart.CartItems.Sum(item => item.TotalPrice);  // Recalculate the cart's total price based on all items

                    // Update the cart in the repository
                    await _unitOfWork.CartRepo.UpdateAsync(cart);
                }

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
                // Decrease the quantity by 1 if it's greater than 1
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity -= 1;

                    // Get the product price
                    var product = await _unitOfWork.ProductRepo.GetByIdAsync(ProductId);
                    cartItem.TotalPrice = cartItem.Quantity * product!.Price;

                    // Update the CartItem
                    await _unitOfWork.CartItemRepo.UpdateAsync(cartItem);
                }
                else if (cartItem.Quantity == 1)
                {
                    // If quantity is 1, remove the CartItem from the cart
                    await _unitOfWork.CartItemRepo.DeleteAsync(cartItem);
                }

                // Update the cart's total price
                var cart = await _unitOfWork.CartRepo.GetByIdAsync(CartId);
                if (cart != null)
                {
                    // Recalculate the total price of the cart
                    cart.TotalPrice = cart.CartItems.Sum(item => item.TotalPrice); // Recalculate the cart's total price based on all items

                    // Update the cart in the repository
                    await _unitOfWork.CartRepo.UpdateAsync(cart);
                }

                if (cart!.TotalPrice==0)
                {
                    cart.IsActive = false;
                }
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("CartItem not found for the provided ProductId and CartId.");
            }
        }


    }
}
