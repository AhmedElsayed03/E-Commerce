using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Abstractions.Repositories
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        IEnumerable<Product> GetAll(int page, int countPerPage);
        int GetCount();
    }
}
