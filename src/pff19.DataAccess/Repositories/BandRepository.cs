using System;
using System.Collections.Generic;
using System.Text;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class BandRepository
    {
        private readonly PffContext _context;

        public BandRepository(PffContext context)
        {
            _context = context;
        }
        public IEnumerable<Band> GetAll()
        {
            return _context.Bands;
        }

        public Band Get(int id)
        {
            return _context.Bands.Find(id);
        }

        public Band Add(Band news)
        {
            _context.Bands.Add(news);
            _context.SaveChanges();
            return news;
        }

        public void Update(Band existingBand)
        {
            _context.Bands.Update(existingBand);
            _context.SaveChanges();
        }

        public void Delete(Band bandToDelete)
        {
            _context.Bands.Remove(bandToDelete);
            _context.SaveChanges();
        }
    }
}
