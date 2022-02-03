using Microsoft.EntityFrameworkCore;

namespace NewsSiteServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NewsItem> NewsItems { get; set; }
    }
}
