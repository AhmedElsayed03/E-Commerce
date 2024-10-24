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
            // Fetch the cart with its items
            var cart = await _unitOfWork.CartRepo.GetCartWithItems(cartId);

            if (cart == null)
            {
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
                TotalPrice = cart.CartItems.Sum(item => item.TotalPrice),
                ItemsNumber = cart.CartItems.Sum(item => item.Quantity)
        };

            // Set IsActive based on the TotalPrice
            if (cartReadDto.TotalPrice != 0)
            {
                cartReadDto.IsActive = true;
            }

            return cartReadDto;
        }


    }
}
