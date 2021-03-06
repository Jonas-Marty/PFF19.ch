﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<BandRequest> BandRequests { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<SocialProgram> SocialPrograms { get; set; }
    }
}
