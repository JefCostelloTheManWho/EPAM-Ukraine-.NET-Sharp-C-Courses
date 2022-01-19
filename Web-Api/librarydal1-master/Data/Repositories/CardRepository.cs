using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(LibraryDbContext context) : base(context)
        {

        }

        public IQueryable<Card> FindAllWithDetails()
        {
            return libraryDbContext.Cards.Select(x => new Card
            {
                Reader = x.Reader,
                ReaderId = x.ReaderId,
                Created = x.Created,
                Books = x.Books,
                Id = x.Id,
                PublicId = x.PublicId
            });
        }

        public Task<Card> GetByIdWithDetailsAsync(int id)
        {
            return libraryDbContext.Cards.Select(x => new Card
            {
                Reader = x.Reader,
                ReaderId = x.ReaderId,
                Created = x.Created,
                Books = x.Books,
                Id = x.Id,
                PublicId = x.PublicId
            }).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
