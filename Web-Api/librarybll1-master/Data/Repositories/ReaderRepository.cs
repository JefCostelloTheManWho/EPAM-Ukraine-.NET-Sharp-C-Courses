using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryDbContext context;
        private readonly DbSet<Reader> dbSet;

        public ReaderRepository(LibraryDbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<Reader>();
        }
        
        public IQueryable<Reader> FindAll()
        {
            return dbSet.AsNoTracking();
        }

        public async Task<Reader> GetByIdAsync(int id)
        {
            return await context.Readers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Reader entity)
        {
            await context.Readers.AddAsync(entity);
        }

        public void Update(Reader entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Reader entity)
        {
            context.Readers.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tmp = await context.Readers.FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(tmp);
        }

        public IQueryable<Reader> GetAllWithDetails()
        {
            return context.Readers.Select(x => new Reader()
            {
                Id = x.Id,
                Cards = x.Cards,
                ReaderProfile = x.ReaderProfile,
                Email = x.Email,
                Name = x.Name
            });
        }

        public Task<Reader> GetByIdWithDetails(int id)
        {
            return context.Readers.Select(x => new Reader()
            {
                Id = x.Id,
                Cards = x.Cards,
                Email = x.Email,
                Name = x.Name,
                ReaderProfile = x.ReaderProfile
            }).FirstOrDefaultAsync(x => x.Id == id);
        }




    }
}