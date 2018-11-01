using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;
using pff19.Models;
using pff19.Utiles;
using SixLabors.Primitives;

namespace pff19.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorsController : ApiControllerBase
    {
        private readonly SponsorRepository _sponsorRepository;
        private readonly FileUtility _fileUtility;
        private readonly IConfiguration _configuration;

        public SponsorsController(SponsorRepository sponsorRepository, FileUtility fileUtility, IConfiguration configuration)
        {
            _sponsorRepository = sponsorRepository;
            _fileUtility = fileUtility;
            _configuration = configuration;
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

        [HttpPost, Authorize, DisableRequestSizeLimit]
        public IActionResult Create([FromForm] SponsorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            Sponsor newSponsor = new Sponsor
            {
                Name = model.Name,
                Link = model.Link,
                Status = model.Status
            };

            SafeSponsorImage(model, newSponsor);

            _sponsorRepository.Update(newSponsor);
            
            return CreatedAtRoute("GetSponsor", new { id = newSponsor.Id }, newSponsor);
        }

        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromForm]SponsorViewModel model)
        {
            var existingSponsor = _sponsorRepository.Get(id);
            if (existingSponsor == null)
            {
                return NotFound();
            }

            SafeSponsorImage(model, existingSponsor);

            existingSponsor.Status = model.Status;
            existingSponsor.Name = model.Name;

            _sponsorRepository.Update(existingSponsor);

            return NoContent();
        }

        [HttpDelete("{id}"), Authorize]
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

        private void SafeSponsorImage(SponsorViewModel model, Sponsor existingSponsor)
        {
            if (model.UploadImage != null)
            {
                string filename = model.Name + Path.GetExtension(model.UploadImage.FileName);
                Size thumbnailSize = new Size(_configuration.GetValue<int>("Images:ThumbnailSize:Sponsors:X"), _configuration.GetValue<int>("Images:ThumbnailSize:Sponsors:Y"));
                _fileUtility.SaveImage(model.UploadImage, "sponsors", filename, thumbnailSize);
                existingSponsor.Logo = filename;
            }
            else
            {
                existingSponsor.Logo = null;
            }
        }
    }
}
