using System.Collections.Generic;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class FaqsRepository
    {
        private readonly PffContext _context;

        public FaqsRepository(PffContext context)
        {
            _context = context;
        }

        public IEnumerable<Faq> GetAll()
        {
            return _context.Faqs;
        }

        public Faq Get(int id)
        {
            return _context.Faqs.Find(id);
        }

        public Faq Add(Faq faq)
        {
            _context.Faqs.Add(faq);
            _context.SaveChanges();
            return faq;
        }

        public void Update(Faq existingFaq)
        {
            _context.Faqs.Update(existingFaq);
            _context.SaveChanges();
        }

        public void Delete(Faq faqToDelete)
        {
            _context.Faqs.Remove(faqToDelete);
            _context.SaveChanges();
        }
    }
}
