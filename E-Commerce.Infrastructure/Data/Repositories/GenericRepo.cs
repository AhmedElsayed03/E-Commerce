using E_Commerce.Application.Abstractions.Repositories;
using E_Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ECommerceDbContext _dbContext;
        public GenericRepo(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                .ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>()
                .FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>()
                .AddAsync(entity);
        }

        public virtual Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
