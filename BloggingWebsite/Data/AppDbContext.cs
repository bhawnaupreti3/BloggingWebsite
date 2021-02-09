using Microsoft.EntityFrameworkCore;

namespace BloggingWebsite.Data
{
    /// <summary>
    /// Class to create db instance
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts{ get; set; }
    }
}
