using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICardService : ICrud<CardModel>
    {
        IEnumerable<BookModel> GetBooksByCardId(int cardId);

        Task TakeBookAsync(int cartId, int bookId);

        Task HandOverBookAsync(int cartId, int bookId);
    }
}