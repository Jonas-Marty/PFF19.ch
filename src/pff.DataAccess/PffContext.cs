using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using pff.DataAccess.Models;

namespace pff.DataAccess
{
    public class PffContext : DbContext
    {
        public PffContext(DbContextOptions<PffContext> options)
            : base(options)
        {
        }

        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<News> News { get; set; }
    }
}
