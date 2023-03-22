using LinkShortener.Context;
using LinkShortener.Models;

namespace LinkShortener.Repository
{
    public class Repository : IRepository<UrlModel>
    {
        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(UrlModel entity)
        {
            _context.Add(entity);
        }

        public UrlModel GetById(string url)
        {
            return _context.Urls.Where(id => id.ShortUrl.Equals(url)).SingleOrDefault();
        }
    }
}
