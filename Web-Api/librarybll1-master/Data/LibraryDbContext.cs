using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<ReaderProfile> ReaderProfiles { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCard>()
                .HasKey(t => new { t.BookId, t.CardId });
            
            modelBuilder.Entity<HistoryReader>()
                .HasKey(t => new { t.HistoryId, t.ReaderId });
        }
    }
}