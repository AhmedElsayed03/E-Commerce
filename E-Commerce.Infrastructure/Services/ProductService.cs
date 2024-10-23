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
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductPaginationDto> GetAll(int page, int countPerPage)
        {
            var products = await _unitOfWork.ProductRepo.GetAll(page, countPerPage);
            var categoryIds = products.Select(p => p.CategoryId).Distinct().ToList();

            // Fetch category names sequentially to avoid concurrency issues
            var categories = new Dictionary<Guid, string>();
            foreach (var categoryId in categoryIds)
            {
                if (!categories.ContainsKey(categoryId))
                {
                    categories[categoryId] = await _unitOfWork.CategoryRepo.GetCategoryNameById(categoryId);
                }
            }

            var productsDto = products.Select(i => new ProductReadDto
            {
                Name = i.Name,
                Price = i.Price,
                CategoryId = i.CategoryId,
                Category = categories.GetValueOrDefault(i.CategoryId)!,
                ImagesUrls = i.Images.Select(image => image.Url).ToList()
            }).ToList();

            int totalCount = await _unitOfWork.ProductRepo.GetCount();

            return new ProductPaginationDto { Products = productsDto, TotalCount = totalCount };
        }





        public async Task<ProductDetailsReadDto> GetProductDetails(Guid id)
        {
            var product = await _unitOfWork.ProductRepo.GetProductDetailsById(id);

            // Fetch the category names in bulk (assuming this can be done for a single category)
            var categoryIds = new List<Guid> { product!.CategoryId };
            var categories = await Task.WhenAll(categoryIds.Select(categoryId => _unitOfWork.CategoryRepo.GetCategoryNameById(categoryId)));

            // Create a lookup for the category name
            var categoryLookup = categoryIds.Zip(categories, (id, name) => new { id, name })
                                             .ToDictionary(x => x.id, x => x.name);

            return new ProductDetailsReadDto
            {
                Name = product!.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = categoryLookup[product.CategoryId], // Lookup the category name
                ImagesUrls = product.Images.Select(image => image.Url).ToList() // Get image URLs
            };
        }



        public async Task AddProduct(ProductAddDto newProduct)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
                CategoryId = newProduct.CategoryId,
                CreateTime =  DateTime.Now
                
            };

            await _unitOfWork.ProductRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
