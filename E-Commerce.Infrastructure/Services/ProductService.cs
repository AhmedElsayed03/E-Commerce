using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Abstractions.UnitOfWork;
using E_Commerce.Application.Models.DTOs;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public ProductService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<ProductPaginationDto> GetAll(int page, Guid? catId)
        {
            var paginateValue = _configuration["paginate"];
            var countPerPage = string.IsNullOrEmpty(paginateValue) ? 3 : int.Parse(paginateValue);

            // Fetch products based on whether catId is provided or not


            var products = await _unitOfWork.ProductRepo.GetCategoryWithAllProducts(page, countPerPage, catId);

            foreach (var x in products)
            {
                Console.WriteLine(x.Id);
            }

            var categoryIds = products.Select(p => p.CategoryId).Distinct().ToList();

            // Fetch category names
            var categories = new Dictionary<Guid, string>();
            foreach (var categoryId in categoryIds)
            {
                if (!categories.ContainsKey(categoryId))
                {
                    categories[categoryId] = await _unitOfWork.CategoryRepo.GetCategoryNameById(categoryId);
                }
            }

            // Convert products to DTOs
            var productsDto = products.Select(i => new ProductReadDto
            {
                Name = i.Name,
                Price = i.Price,
                CategoryId = i.CategoryId,
                Category = categories.GetValueOrDefault(i.CategoryId)!,
                ImagesUrls = i.Images.Select(image => image.Url).ToList(),
                ProductId = i.Id
            }).ToList();


            // Calculate total count and pages
            int totalCount = await _unitOfWork.ProductRepo.GetCount();

            if (catId != null)
            {
                var x = await _unitOfWork.CategoryRepo.GetCategoryWithProducts(catId!.Value);
                totalCount = x != null ? x.Products.Count() : 0;
            }
            


            int totalPages = (int)Math.Ceiling((double)totalCount / countPerPage);

            return new ProductPaginationDto { Products = productsDto, TotalPages = totalPages };
        }





        public async Task<ProductDetailsReadDto?> GetProductDetails(Guid id)
        {
            var product = await _unitOfWork.ProductRepo.GetProductDetailsById(id);

            if (product == null)
            {
                return null;
            }
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
                ProductId = product.Id,
                //IsAdded = product.IsAdded,
                Category = categoryLookup[product.CategoryId], // Lookup the category name
                ImagesUrls = product.Images.Select(image => image.Url).ToList() // Get image URLs,
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
                CreateTime =  DateTime.Now,
                //IsAdded = true,
                
            };

            await _unitOfWork.ProductRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
