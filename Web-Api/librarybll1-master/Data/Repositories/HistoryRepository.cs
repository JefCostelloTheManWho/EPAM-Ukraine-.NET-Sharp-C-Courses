using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly LibraryDbContext context;
        private readonly DbSet<History> dbSet;

        public HistoryRepository(LibraryDbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<History>();
        }
        public IQueryable<History> FindAll()
        {
            return dbSet.AsNoTracking();
        }

        public async Task<History> GetByIdAsync(int id)
        {
            return await context.Histories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(History entity)
        {
            await context.Histories.AddAsync(entity);
        }

        public void Update(History entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(History entity)
        {
            context.Histories.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tmp = await context.Histories.FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(tmp);
        }

        public IQueryable<History> GetAllWithDetails()
        {
            IQueryable<History> query = dbSet;
            return query.OrderBy(x => x.Id);
            
        }
    }
}