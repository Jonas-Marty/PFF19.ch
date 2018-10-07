using System.Collections.Generic;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class BandRequestRepository
    {
        private readonly PffContext _context;

        public BandRequestRepository(PffContext context)
        {
            _context = context;
        }

        public IEnumerable<BandRequest> GetAll()
        {
            return _context.BandRequests;
        }

        public BandRequest Get(int id)
        {
            return _context.BandRequests.Find(id);
        }

        public BandRequest Add(BandRequest bandRequest)
        {
            _context.BandRequests.Add(bandRequest);
            _context.SaveChanges();
            return bandRequest;
        }

        public void Update(BandRequest existingBandRequest)
        {
            _context.BandRequests.Update(existingBandRequest);
            _context.SaveChanges();
        }

        public void Delete(BandRequest bandRequestToDelete)
        {
            _context.BandRequests.Remove(bandRequestToDelete);
            _context.SaveChanges();
        }
    }
}
