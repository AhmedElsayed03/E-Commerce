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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCategory(CategoryAddDto newCategory)
        {
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = newCategory.Name,
                CreateTime = DateTime.Now

            };

            await _unitOfWork.CategoryRepo.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CategoryWithProductsDto> GetCategoryWithProducts(Guid id)
        {
            // Fetch the category with products
            var category = await _unitOfWork.CategoryRepo.GetCategoryWithProducts(id);

            // Check if the category exists
            if (category == null)
            {
                return null!; // or throw an exception if you prefer
            }

            // Map category to DTO
            var categoryDto = new CategoryWithProductsDto
            {
                Name = category.Name,
                Products = category.Products.Select(product => new ProductReadDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Category = category.Name,
                    ImagesUrls = product.Images.Select(image => image.Url).ToList()
                }).ToList()
            };

            return categoryDto;
        }
    }
}
