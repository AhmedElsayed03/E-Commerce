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


        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }
        public T? GetByID(int Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }
        public void Add(T item)
        {
            _dbContext.Set<T>().Add(item);
        }
        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
        }
        public void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
