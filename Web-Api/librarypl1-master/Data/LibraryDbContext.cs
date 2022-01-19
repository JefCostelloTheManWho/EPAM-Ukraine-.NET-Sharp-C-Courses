using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }


        public DbSet<Book> Books { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<History> Histories { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<ReaderProfile> ReaderProfiles { get; set; }
    }
}