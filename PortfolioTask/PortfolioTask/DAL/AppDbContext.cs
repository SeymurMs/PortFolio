using Microsoft.EntityFrameworkCore;
using PortfolioTask.Models;

namespace PortfolioTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<About> About{ get; set; }

    }
}
