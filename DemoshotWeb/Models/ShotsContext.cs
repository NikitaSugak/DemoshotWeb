using Microsoft.EntityFrameworkCore;

namespace DemoshotWeb.Models
{
    public class ShotsContext : DbContext
    {
        public DbSet<Shot> Shots { get; set; }
        public ShotsContext(DbContextOptions<ShotsContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
