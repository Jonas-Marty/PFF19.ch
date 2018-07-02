using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;

namespace pff19.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorsController : Controller
    {
        private readonly SponsorRepository _sponsorRepository;

        public SponsorsController(SponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sponsor>> Get()
        {
            return _sponsorRepository.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetSponsor")]
        public ActionResult<Sponsor> Get(int id)
        {
            return _sponsorRepository.Get(id);
        }

        [HttpPost]
        public IActionResult Create(Sponsor sponsor)
        {
            _sponsorRepository.Add(sponsor);
            return CreatedAtRoute("GetSponsor", new {id = sponsor.Id}, sponsor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Sponsor sponsor)
        {
            var existingSponsor = _sponsorRepository.Get(id);
            if (existingSponsor == null)
            {
                return NotFound();
            }

            existingSponsor.Status = sponsor.Status;
            existingSponsor.Link = sponsor.Link;
            existingSponsor.Logo = sponsor.Logo;
            existingSponsor.Name = sponsor.Name;

            _sponsorRepository.Update(existingSponsor);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingSponsor = _sponsorRepository.Get(id);
            if (existingSponsor == null)
            {
                return NotFound();
            }

            _sponsorRepository.Delete(existingSponsor);

            return NoContent();
        }
    }
}
