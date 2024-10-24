using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Abstractions.UnitOfWork;
using E_Commerce.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CartReadDto> GetCartWithElements(Guid cartId)
        {
            // Step 1: Get the cart with items using the existing method
            var cart = await _unitOfWork.CartRepo.GetCartWithItems(cartId);

            // Step 2: Map the Cart to CartReadDto
            if (cart == null)
            {
                // Handle the case where the cart doesn't exist, e.g., return null or throw an exception
                throw new InvalidOperationException("Cart not found.");
            }

            var cartReadDto = new CartReadDto
            {
                CartItems = cart.CartItems.Select(item => new CartItemReadDto
                {
                    productDetailsReadDto = new ProductDetailsReadDto
                    {
                        Name = item.Product!.Name,
                        Description = item.Product.Description,
                        Price = item.Product.Price,
                        ImagesUrls = item.Product.Images.Select(img => img.Url).ToList(),
                        ProductId = item.ProductId,
                    },
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                }).ToList(),
                TotalPrice = cart.CartItems.Sum(item => item.TotalPrice), // Optionally calculate total price here
            };
            if (cartReadDto.TotalPrice != 0) 
            {
                cartReadDto.IsActive = true;
            }
            
                

            // Step 3: Return the DTO
            return cartReadDto;
        }

    }
}
