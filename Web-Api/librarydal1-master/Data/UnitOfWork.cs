using System;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields
        private readonly LibraryDbContext _context;
        private BookRepository _bookRepository;
        private CardRepository _cardRepository;
        private HistoryRepository _historyRepository;
        private ReaderRepository _readerRepository;
        private bool _disposed = false;
        #endregion

        public UnitOfWork(DbContextOptions<LibraryDbContext> optionsBuilder)
        {
            _context = new LibraryDbContext(optionsBuilder);
        }

        #region Properties
        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_context);
                return _bookRepository;
            }
        }

        public ICardRepository CardRepository
        {
            get
            {
                if (_cardRepository == null)
                    _cardRepository = new CardRepository(_context);
                return _cardRepository;
            }
        }

        public IHistoryRepository HistoryRepository
        {
            get
            {
                if (_historyRepository == null)
                    _historyRepository = new HistoryRepository(_context);
                return _historyRepository;
            }
        }

        public IReaderRepository ReaderRepository
        {
            get
            {
                if (_readerRepository == null)
                    _readerRepository = new ReaderRepository(_context);
                return _readerRepository;
            }
        }
        #endregion
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}