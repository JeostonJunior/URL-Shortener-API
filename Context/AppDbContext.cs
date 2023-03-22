using LinkShortener.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UrlModel> Urls { get; set; }
    }
}
