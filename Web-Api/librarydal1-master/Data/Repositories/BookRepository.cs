using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {

        }

        public new Task AddAsync(Book entity)
        {
            return Task.Run(() => libraryDbContext.Books.AddAsync(entity));
        }

        public new void Delete(Book entity)
        {
            libraryDbContext.Books.Remove(entity);
        }

        public new Task DeleteByIdAsync(int id)
        {
            return Task.Run(()=> libraryDbContext.Remove(GetByIdAsync(id).Result));
        }

        public new IQueryable<Book> FindAll()
        {
            return libraryDbContext.Books;
        }

        public IQueryable<Book> FindAllWithDetails()
        {
            return libraryDbContext.Books.Select(b => new Book
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Cards = b.Cards,
                PublicId = b.PublicId,
                Year = b.Year
            });
        }

        public new Task<Book> GetByIdAsync(int id)
        {
            return libraryDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<Book> GetByIdWithDetailsAsync(int id)
        {
            return libraryDbContext.Books.Select(b => new Book
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Cards = b.Cards,
                PublicId = b.PublicId,
                Year = b.Year
            }).FirstOrDefaultAsync(b => b.Id == id);
        }

        public new void Update(Book entity)
        {
            libraryDbContext.Books.Update(entity);
            libraryDbContext.Entry(entity).State = EntityState.Modified;
            libraryDbContext.SaveChanges();
        }
    }
}
