using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IQueryable<Book> FindAllWithDetails();

        Task<Book> GetByIdWithDetailsAsync(int id);
    }
}