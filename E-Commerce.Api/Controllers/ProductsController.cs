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
        [Route("all/{page}")]
        public async Task<ProductPaginationDto> GetAll(int page ,[FromQuery] Guid? catId = null)
        {
            return await _productService.GetAll(page , catId);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDetailsReadDto>> GetProductDetailsById(Guid productId)
        {
            var product = await _productService.GetProductDetails(productId);

            if (product == null)
            {
                return NotFound(); // Returns a 404 response
            }
            await Task.Delay(200);
            return Ok(product); // Returns a 200 response with the product data
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
