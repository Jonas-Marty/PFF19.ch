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
    public class BandsController : ApiControllerBase
    {
        private const string GetBandRouteName = "GetBands";
        private readonly BandRepository _bandRepository;

        public BandsController(BandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        // GET: api/Bands
        [HttpGet]
        public ActionResult<IEnumerable<Band>> Get()
        {
            return _bandRepository.GetAll().ToList();
        }

        // GET: api/Bands/5
        [HttpGet("{id}", Name = GetBandRouteName)]
        public Band Get(int id)
        {
            return _bandRepository.Get(id);
        }

        // POST: api/Bands
        [HttpPost]
        public IActionResult Post(Band band)
        {
            _bandRepository.Add(band);
            return CreatedAtRoute(GetBandRouteName, new { id = band.Id }, band);
        }

        // PUT: api/Bands/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, Band band)
        {
            var existingBand = _bandRepository.Get(id);
            if (existingBand == null)
            {
                return NotFound();
            }

            existingBand.Name = band.Name;
            existingBand.DescriptionDe = band.DescriptionDe;
            existingBand.DescriptionFr = band.DescriptionFr;


            _bandRepository.Update(existingBand);

            return NoContent();
        }

        // DELETE: api/Bands/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var existingBand = _bandRepository.Get(id);
            if (existingBand == null)
            {
                return NotFound();
            }

            _bandRepository.Delete(existingBand);

            return NoContent();
        }
    }
}
