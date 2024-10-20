using E_Commerce.Application.Abstractions.Repositories;
using E_Commerce.Application.Abstractions.UnitOfWork;
using E_Commerce.Infrastructure.Data.Context;
using E_Commerce.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepo ProductRepo { get; }
        public IImageRepo ImageRepo { get; }
        private readonly ECommerceDbContext _context;

        public UnitOfWork(ECommerceDbContext context,
                          IProductRepo productRepo,
                          IImageRepo imageRepo)
        {
                          _context = context;
                          ProductRepo = productRepo;
                          ImageRepo = imageRepo;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
