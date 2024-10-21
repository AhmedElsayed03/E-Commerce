using E_Commerce.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IProductRepo ProductRepo { get; }
        public IImageRepo ImageRepo { get; }
        public ICategoryRepo CategoryRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
