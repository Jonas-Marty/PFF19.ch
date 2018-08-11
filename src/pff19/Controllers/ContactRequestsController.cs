using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;

namespace pff19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRequestsController : ApiControllerBase
    {
        private const string GetContactRequestRouteName = "GetContactRequests";
        private readonly ContactRequestRepository _contactRequestRepository;

        public ContactRequestsController(ContactRequestRepository contactRequestRepository)
        {
            _contactRequestRepository = contactRequestRepository;
        }

        // GET: api/ContactRequests
        [HttpGet, Authorize]
        public ActionResult<IEnumerable<ContactRequest>> Get()
        {
            return _contactRequestRepository.GetAll().ToList();
        }

        // GET: api/ContactRequests/5
        [HttpGet("{id}", Name = GetContactRequestRouteName), Authorize]
        public ContactRequest Get(int id)
        {
            return _contactRequestRepository.Get(id);
        }

        // POST: api/ContactRequests
        [HttpPost]
        public IActionResult Post(ContactRequest contactRequest)
        {
            _contactRequestRepository.Add(contactRequest);
            return CreatedAtRoute(GetContactRequestRouteName, new { id = contactRequest.Id }, contactRequest);
        }

        // PUT: api/ContactRequests/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, ContactRequest contactRequest)
        {
            var existingContactRequest = _contactRequestRepository.Get(id);
            if (existingContactRequest == null)
            {
                return NotFound();
            }

            existingContactRequest.FirstName = contactRequest.FirstName;
            existingContactRequest.LastName = contactRequest.LastName;
            existingContactRequest.Mail = contactRequest.Mail;
            existingContactRequest.Text = contactRequest.Text;

            _contactRequestRepository.Update(existingContactRequest);

            return NoContent();
        }

        // DELETE: api/ContactRequests/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var existingContactRequest = _contactRequestRepository.Get(id);
            if (existingContactRequest == null)
            {
                return NotFound();
            }

            _contactRequestRepository.Delete(existingContactRequest);

            return NoContent();
        }
    }
}
