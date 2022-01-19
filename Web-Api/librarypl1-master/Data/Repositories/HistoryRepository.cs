using System.Linq;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {
        public HistoryRepository(LibraryDbContext context) : base(context) { }


        public IQueryable<History> GetAllWithDetails()
        {
            return FindAll()
                .Include(h => h.Book)
                .Include(h => h.Card)
                .ThenInclude(c => c.Reader);
        }
    }
}