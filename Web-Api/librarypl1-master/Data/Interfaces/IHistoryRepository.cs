using System.Linq;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IHistoryRepository : IRepository<History>
    {
        IQueryable<History> GetAllWithDetails();
    }
}