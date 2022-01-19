using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly LibraryDbContext context;
        private readonly DbSet<Card> dbSet;

        public CardRepository(LibraryDbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<Card>();
        }
        public IQueryable<Card> FindAll()
        {
            return dbSet.AsNoTracking();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await context.Cards.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Card entity)
        {
            await context.Cards.AddAsync(entity);
        }

        public void Update(Card entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Card entity)
        {
            context.Cards.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tmp = await context.Cards.FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(tmp);
        }

        public async Task<Card> GetByIdWithDetailsAsync(int id)
        {
            return await context.Cards.Select(x => new Card
            {
                Reader = x.Reader,
                ReaderId = x.ReaderId,
                Created = x.Created,
                Books = x.Books,
                Id = x.Id,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Card> FindAllWithDetails()
        {
            return context.Cards.Select(x => new Card
            {
                Reader = x.Reader,
                ReaderId = x.ReaderId,
                Created = x.Created,
                Books = x.Books,
                Id = x.Id,
            });
        }
    }
}