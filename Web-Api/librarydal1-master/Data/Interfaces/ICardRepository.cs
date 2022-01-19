using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<Card> GetByIdWithDetailsAsync(int id);
        IQueryable<Card> FindAllWithDetails();
    }
}
