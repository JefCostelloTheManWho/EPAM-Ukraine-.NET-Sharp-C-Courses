using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IReaderRepository : IRepository<Reader>
    {
        IQueryable<Reader> GetAllWithDetails();
        Task<Reader> GetByIdWithDetails(int id);
    }
}
