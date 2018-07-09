using Microsoft.EntityFrameworkCore;
using pff19.DataAccess.Models;

namespace pff19.DataAccess
{
    public class PffContext : DbContext
    {
        public PffContext(DbContextOptions<PffContext> options)
            : base(options)
        {
        }

        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
