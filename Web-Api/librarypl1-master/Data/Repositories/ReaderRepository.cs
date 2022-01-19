using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ReaderRepository : Repository<Reader>, IReaderRepository
    {
        public ReaderRepository(LibraryDbContext context) : base(context)
        {
        }

        public IQueryable<Reader> GetAllWithDetails()
        {
            return FindAll()
                .Include(x => x.ReaderProfile)
                .Include(x => x.Cards);
        }

        public async Task<Reader> GetByIdWithDetails(int id)
        {
            return await FindAll()
                .Include(x => x.ReaderProfile)
                .Include(x => x.Cards)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
