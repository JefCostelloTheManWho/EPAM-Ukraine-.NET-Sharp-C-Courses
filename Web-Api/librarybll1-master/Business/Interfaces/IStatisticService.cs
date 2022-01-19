using System;
using System.Collections.Generic;
using Business.Models;

namespace Business.Interfaces
{
    public interface IStatisticService
    {
        IEnumerable<BookModel> GetMostPopularBooks(int bookCount);
        
        IEnumerable<ReaderActivityModel> GetReadersWhoTookTheMostBooks(int readersCount, DateTime firstDate, DateTime lastDate);
    }
}