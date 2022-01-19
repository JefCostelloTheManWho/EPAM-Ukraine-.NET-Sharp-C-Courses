using System;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryDbContext _context { get; }

        public UnitOfWork(LibraryDbContext _LibraryDbContext)
        {
            this._context = _LibraryDbContext;
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        private IBookRepository _bookRepository;

        public IBookRepository BookRepository
        {
            get { return _bookRepository ?? (_bookRepository = new BookRepository(_context)); }
        }

        private ICardRepository _cardRepository;

        public ICardRepository CardRepository
        {
            get { return _cardRepository ?? (_cardRepository = new CardRepository(_context)); }
        }

        private IHistoryRepository _historyRepository;

        public IHistoryRepository HistoryRepository
        {
            get { return _historyRepository ?? (_historyRepository = new HistoryRepository(_context)); }
        }

        private IReaderRepository _readerRepository;

        public IReaderRepository ReaderRepository
        {
            get { return _readerRepository ?? (_readerRepository = new ReaderRepository(_context)); }
        }
    }
}