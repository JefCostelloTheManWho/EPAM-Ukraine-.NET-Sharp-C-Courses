using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
            
        }

        public IQueryable<Book> FindAllWithDetails()
        {
            return DbSet.Include(b => b.Cards);
        }

        public async Task<Book> GetByIdWithDetailsAsync(int id)
        {
            return await DbSet
                .Include(b => b.Cards)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}