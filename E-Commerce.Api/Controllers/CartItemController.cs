using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Models.DTOs;
using E_Commerce.Infrastructure.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost]
        [Route("Add-Item")]
        public async Task<NoContent> AddItemToCart(Guid productId, Guid cartId)
        {
            await _cartItemService.AddItemToCart(productId, cartId);
            return TypedResults.NoContent();
        }

        [HttpPost]
        [Route("Plus-Count")]
        public async Task<NoContent> PlusCount(Guid productId, Guid cartId)
        {
            await _cartItemService.PlusCount(productId, cartId);
            return TypedResults.NoContent();
        }

        [HttpPost]
        [Route("Minus-Count")]
        public async Task<NoContent> MinusCount(Guid productId, Guid cartId)
        {
            await _cartItemService.MinusCount(productId, cartId);
            return TypedResults.NoContent();
        }
    }
}
