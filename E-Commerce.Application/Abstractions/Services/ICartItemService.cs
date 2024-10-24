using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Abstractions.Services
{
    public interface ICartItemService
    {
        Task AddItemToCart(Guid ProductId, Guid CartId);
        Task PlusCount(Guid ProductId, Guid CartId);
        Task MinusCount(Guid ProductId, Guid CartId);
        Task DeleteItem(Guid ProductId, Guid CartId);
    }
}
