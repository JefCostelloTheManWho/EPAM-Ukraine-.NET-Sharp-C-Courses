using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly LibraryDbContext libraryDbContext;
        public BaseRepository(LibraryDbContext context)
        {
            libraryDbContext = context;
        }

        public Task AddAsync(T entity)
        {
            return Task.Run(() => libraryDbContext.Set<T>().AddAsync(entity));
        }

        public void Delete(T entity)
        {
            libraryDbContext.Set<T>().Remove(entity);
        }

        public Task DeleteByIdAsync(int id)
        {
            return Task.Run(() => libraryDbContext.Set<T>().Remove(GetByIdAsync(id).Result));
        }

        public System.Linq.IQueryable<T> FindAll()
        {
            return libraryDbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await libraryDbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            libraryDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            libraryDbContext.Set<T>().Update(entity);
        }
    }
}
