using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Abstractions.Repositories
{
    public interface ICartItemRepo : IGenericRepo<CartItem>
    {
        Task<CartItem?> FindAsync(Func<CartItem, bool> predicate);
    }
}
