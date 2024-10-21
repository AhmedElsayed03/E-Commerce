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
            var productsDto = products.Select(i => new ProductReadDto
            {
                Name = i.Name,
                Price = i.Price,
                Category = i.Category

            });

            int totalCount = await _unitOfWork.ProductRepo.GetCount();

            return new ProductPaginationDto { Products = productsDto, TotalCount = totalCount };
        }



        public async Task<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var products = await _unitOfWork.ProductRepo.GetAllAsync();
            var productsDto = products.Select(i => new ProductReadDto
            {
                Name = i.Name,
                Price = i.Price,
                Category = i.Category

            });

            return productsDto;
        }

        public async Task<ProductDetailsReadDto> GetProductDetails(int Id)
        {
            var product = await _unitOfWork.ProductRepo.GetByIdAsync(Id);

            return new ProductDetailsReadDto
            {

                Name = product!.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category

            };
        }


        public async Task AddProduct(ProductAddDto newProduct)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = newProduct.Name,
                Price = newProduct.Price,
                Category = newProduct.Category,
                Description = newProduct.Description
            };

            await _unitOfWork.ProductRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
