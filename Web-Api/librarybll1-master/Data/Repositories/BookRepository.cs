using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext context;
        private readonly DbSet<Book> dbSet;

        public BookRepository(LibraryDbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<Book>();
        }

        public IQueryable<Book> FindAll()
        {
            return dbSet.AsNoTracking();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Book entity)
        {
            await context.Books.AddAsync(entity);
        }

        public void Update(Book entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Book entity)
        {
            context.Books.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tmp = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(tmp);
        }

        public IQueryable<Book> FindAllWithDetails()
        {
            return context.Books.Select(b => new Book
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Cards = b.Cards,
                Year = b.Year
            });
        }

        public async Task<Book> GetByIdWithDetailsAsync(int id)
        {
            return await context.Books.Where(x => x.Id == id).Include(p => p.Cards).FirstOrDefaultAsync();
        }
    }
}