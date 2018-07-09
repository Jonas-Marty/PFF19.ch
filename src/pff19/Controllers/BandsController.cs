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
    public class BandsController : ControllerBase
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
        public IActionResult Post(Band news)
        {
            _bandRepository.Add(news);
            return CreatedAtRoute(GetBandRouteName, new { id = news.Id }, news);
        }

        // PUT: api/Bands/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Band band)
        {
            var existingBand = _bandRepository.Get(id);
            if (existingBand == null)
            {
                return NotFound();
            }

            existingBand.Description = band.Description;
            existingBand.Mail = band.Mail;
            existingBand.Phone = band.Phone;
            existingBand.ReferenceToScout = band.ReferenceToScout;

            _bandRepository.Update(existingBand);

            return NoContent();
        }

        // DELETE: api/Bands/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingNews = _bandRepository.Get(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            _bandRepository.Delete(existingNews);

            return NoContent();
        }
    }
}
