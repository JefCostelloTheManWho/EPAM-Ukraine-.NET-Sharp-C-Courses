using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> DbSet;
        
        public Repository(LibraryDbContext context)
        {
            DbSet = context.Set<TEntity>();
        }
 
        public IQueryable<TEntity> FindAll()
        {
            return DbSet;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }
 
        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
 
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }
    }
}