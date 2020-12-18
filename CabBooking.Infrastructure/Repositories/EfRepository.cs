using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Repositories
{
    //generic type repository which help reduce the redundency. specificy until the class or the method is declared and instatiated.
    //add constarains to be type safe 
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {

        protected readonly CabBookingDbContext _dbContext;

        //dependency injection of the database context to the repository
        public EfRepository(CabBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            // Mark::
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if(filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null)
        {
            if(filter != null && await _dbContext.Set<T>().Where(filter).AnyAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //one way 
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
