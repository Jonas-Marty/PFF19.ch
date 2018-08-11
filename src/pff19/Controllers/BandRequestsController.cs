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
    public class BandRequestsController : ApiControllerBase
    {
        private const string GetBandRequestRouteName = "GetBandRequests";
        private readonly BandRequestRepository _bandRequestRepository;

        public BandRequestsController(BandRequestRepository bandRequestRepository)
        {
            _bandRequestRepository = bandRequestRepository;
        }

        // GET: api/BandRequests
        [HttpGet, Authorize]
        public ActionResult<IEnumerable<BandRequest>> Get()
        {
            return _bandRequestRepository.GetAll().ToList();
        }

        // GET: api/BandRequests/5
        [HttpGet("{id}", Name = GetBandRequestRouteName), Authorize]
        public BandRequest Get(int id)
        {
            return _bandRequestRepository.Get(id);
        }

        // POST: api/BandRequests
        [HttpPost]
        public IActionResult Post(BandRequest bandRequest)
        {
            _bandRequestRepository.Add(bandRequest);
            return CreatedAtRoute(GetBandRequestRouteName, new { id = bandRequest.Id }, bandRequest);
        }

        // PUT: api/BandRequests/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, BandRequest bandRequest)
        {
            var existingBandRequest = _bandRequestRepository.Get(id);
            if (existingBandRequest == null)
            {
                return NotFound();
            }

            existingBandRequest.Name = bandRequest.Name;
            existingBandRequest.Email = bandRequest.Email;
            existingBandRequest.Phone = bandRequest.Phone;
            existingBandRequest.ReferenceToScout = bandRequest.ReferenceToScout;

            _bandRequestRepository.Update(existingBandRequest);

            return NoContent();
        }

        // DELETE: api/BandRequests/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var existingContactRequest = _bandRequestRepository.Get(id);
            if (existingContactRequest == null)
            {
                return NotFound();
            }

            _bandRequestRepository.Delete(existingContactRequest);

            return NoContent();
        }
    }
}
