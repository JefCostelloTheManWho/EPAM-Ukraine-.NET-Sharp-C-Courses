using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(LibraryDbContext context) : base(context)
        {
        }

        public IQueryable<Card> FindAllWithDetails()
        {
            return DbSet.Include(x => x.Books)
                .Include(x => x.Reader);
        }

        public async Task<Card> GetByIdWithDetailsAsync(int id)
        {
            return await DbSet.Include(x => x.Books)
                .Include(x => x.Reader)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
