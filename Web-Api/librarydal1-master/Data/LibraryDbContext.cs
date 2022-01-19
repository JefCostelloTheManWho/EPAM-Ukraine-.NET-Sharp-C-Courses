using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        /// <summary>
        /// Book db set
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Histories db set
        /// </summary>
        public DbSet<History> Histories { get; set; }

        /// <summary>
        /// Cards db set
        /// </summary>
        public DbSet<Card> Cards { get; set; }

        /// <summary>
        /// Readers db set
        /// </summary>
        public DbSet<Reader> Readers { get; set; }

        /// <summary>
        /// ReaderProfiles db set
        /// </summary>
        public DbSet<ReaderProfile> ReaderProfiles { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
           
            
        }
    }
}