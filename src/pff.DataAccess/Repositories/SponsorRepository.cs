using System;
using System.Collections.Generic;
using System.Text;
using pff.DataAccess.Models;

namespace pff.DataAccess.Repositories
{
    public class SponsorRepository
    {
        private readonly PffContext _context;

        public SponsorRepository(PffContext context)
        {
            _context = context;
        }

        public IEnumerable<Sponsor> GetSponsors()
        {
            return _context.Sponsors;
        }
    }
}
