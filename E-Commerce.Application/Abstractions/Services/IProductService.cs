using E_Commerce.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<ProductPaginationDto> GetAll(int page , Guid? catId);
        Task AddProduct(ProductAddDto newProduct);
        Task<ProductDetailsReadDto?> GetProductDetails(Guid Id);
    }
}
