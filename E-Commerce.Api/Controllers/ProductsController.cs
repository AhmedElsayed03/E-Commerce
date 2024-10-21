using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("{page}/{countPerPage}")]
        public async Task<ProductPaginationDto> GetAll(int page, int countPerPage)
        {
            return await _productService.GetAll(page, countPerPage);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ProductDetailsReadDto> GetProductDetailsById(Guid productId)
        {
            return await _productService.GetProductDetails(productId);
        }


        [HttpPost]
        [Route("Add-Product")]
        public async Task<NoContent> AddProduct(ProductAddDto newProduct)
        {
            await _productService.AddProduct(newProduct);
            return TypedResults.NoContent();
        }
    }
}
