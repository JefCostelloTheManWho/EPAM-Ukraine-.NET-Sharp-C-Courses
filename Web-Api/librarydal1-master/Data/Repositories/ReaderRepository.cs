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
    public class ReaderRepository : BaseRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(LibraryDbContext context) : base(context)
        {
            
        }

        public IQueryable<Reader> GetAllWithDetails()
        {
            return libraryDbContext.Readers.Select(x => new Reader()
            {
                Id = x.Id,
                PublicId = x.PublicId,
                Cards = x.Cards,
                ReaderProfile = x.ReaderProfile,
                Email = x.Email,
                Name = x.Name
            });
        }

        public Task<Reader> GetByIdWithDetails(int id)
        {
            return libraryDbContext.Readers.Select(x => new Reader()
            {
                Id = x.Id,
                Cards = x.Cards,
                Email = x.Email,
                Name = x.Name,
                PublicId = x.PublicId,
                ReaderProfile = x.ReaderProfile
            }).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
