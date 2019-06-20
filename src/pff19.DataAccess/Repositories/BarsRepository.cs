using System.Collections.Generic;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class BarsRepository
    {
        private readonly PffContext _context;

        public BarsRepository(PffContext context)
        {
            _context = context;
        }
        public IEnumerable<Bar> GetAll()
        {
            return _context.Bars;
        }

        public Bar Get(int id)
        {
            return _context.Bars.Find(id);
        }

        public Bar Add(Bar bar)
        {
            _context.Bars.Add(bar);
            _context.SaveChanges();
            return bar;
        }

        public void Update(Bar existingBar)
        {
            _context.Bars.Update(existingBar);
            _context.SaveChanges();
        }

        public void Delete(Bar barToDelete)
        {
            _context.Bars.Remove(barToDelete);
            _context.SaveChanges();
        }
    }
}
