using System.Collections.Generic;
using Business.Models;

namespace Business.Interfaces
{
    public interface IReaderService : ICrud<ReaderModel>
    {
        IEnumerable<ReaderModel> GetReadersThatDontReturnBooks();
    }
}