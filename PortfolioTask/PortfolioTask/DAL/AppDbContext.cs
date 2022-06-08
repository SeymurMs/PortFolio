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
        public DbSet<Experience> experiences{ get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Skills> skills { get; set; }
        public DbSet<ProgrammingLan> programmingLans { get; set; }
        public DbSet<WorkFlows> workFlows { get; set; }

    }
}
