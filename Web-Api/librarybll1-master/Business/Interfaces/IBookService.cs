using System.Collections.Generic;
using Business.Models;

namespace Business.Interfaces
{
    public interface IBookService : ICrud<BookModel>
    {
        IEnumerable<BookModel> GetByFilter(FilterSearchModel filterSearch);
    }
}