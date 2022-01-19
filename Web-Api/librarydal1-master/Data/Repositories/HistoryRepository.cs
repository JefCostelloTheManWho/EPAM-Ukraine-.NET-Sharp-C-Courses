using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class HistoryRepository : BaseRepository<History>, IHistoryRepository
    {
        public HistoryRepository(LibraryDbContext context) : base(context)
        {

        }
        public IQueryable<History> GetAllWithDetails()
        {
            return libraryDbContext.Histories.Select(x => new History
            {
                Id = x.Id,
                PublicId = x.PublicId,
                Book = x.Book,
                ReturnDate = x.ReturnDate,
                TakeDate = x.TakeDate,
                BookId = x.BookId,
                Card = x.Card,
                CardId = x.CardId
            });
        }
    }
}
