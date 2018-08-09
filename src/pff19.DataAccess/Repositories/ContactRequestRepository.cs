using System.Collections.Generic;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class ContactRequestRepository
    {
        private readonly PffContext _context;

        public ContactRequestRepository(PffContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactRequest> GetAll()
        {
            return _context.ContactRequests;
        }

        public ContactRequest Get(int id)
        {
            return _context.ContactRequests.Find(id);
        }

        public ContactRequest Add(ContactRequest contactRequest)
        {
            _context.ContactRequests.Add(contactRequest);
            _context.SaveChanges();
            return contactRequest;
        }

        public void Update(ContactRequest existingContactRequest)
        {
            _context.ContactRequests.Update(existingContactRequest);
            _context.SaveChanges();
        }

        public void Delete(ContactRequest contactRequestToDelete)
        {
            _context.ContactRequests.Remove(contactRequestToDelete);
            _context.SaveChanges();
        }
    }
}
