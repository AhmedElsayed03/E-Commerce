using E_Commerce.Application.Abstractions.Repositories;
using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Abstractions.UnitOfWork;
using E_Commerce.Infrastructure.Data.Context;
using E_Commerce.Infrastructure.Data.Repositories;
using E_Commerce.Infrastructure.Data.UnitOfWork;
using E_Commerce.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion


            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IImageRepo, ImageRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            #endregion


            #region Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion

            return services;
        }
    }
}
