using LinkShortener.Context;

namespace LinkShortener.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Repository _urlRepository;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public Repository UrlRepository
        {
            get { return _urlRepository = _urlRepository ?? new Repository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
