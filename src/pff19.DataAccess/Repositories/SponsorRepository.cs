using System;
using System.Collections.Generic;
using System.Text;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class SponsorRepository
    {
        private readonly PffContext _context;

        public SponsorRepository(PffContext context)
        {
            _context = context;
        }

        public IEnumerable<Sponsor> GetAll()
        {
            return _context.Sponsors;
        }

        public Sponsor Get(int id)
        {
            return _context.Sponsors.Find(id);
        }

        public Sponsor Add(Sponsor sponsor)
        {
            _context.Sponsors.Add(sponsor);
            _context.SaveChanges();
            return sponsor;
        }

        public void Update(Sponsor existingSponsor)
        {
            _context.Sponsors.Update(existingSponsor);
            _context.SaveChanges();
        }

        public void Delete(Sponsor sponsorToDelete)
        {
            _context.Sponsors.Remove(sponsorToDelete);
            _context.SaveChanges();
        }
    }
}
