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
    [Route("api/[controller]")]
    [ApiController]
    public class SocialProgramsController : ApiControllerBase
    {
        private const string GetSocialProgramRouteName = "GetSocialPrograms";
        private readonly SocialProgramsRepository _socialProgramsRepository;
        private readonly IConfiguration _configuration;
        private readonly FileUtility _fileUtility;

        public SocialProgramsController(SocialProgramsRepository socialProgramsRepository, IConfiguration configuration, FileUtility fileUtility)
        {
            _socialProgramsRepository = socialProgramsRepository;
            _configuration = configuration;
            _fileUtility = fileUtility;
        }

        // GET: api/SocialPrograms
        [HttpGet]
        public ActionResult<IEnumerable<SocialProgram>> Get()
        {
            return _socialProgramsRepository.GetAll().ToList();
        }

        // GET: api/SocialPrograms/5
        [HttpGet("{id}", Name = GetSocialProgramRouteName)]
        public SocialProgram Get(int id)
        {
            return _socialProgramsRepository.Get(id);
        }

        // POST: api/SocialPrograms
        [HttpPost]
        public IActionResult Post([FromForm] SocialProgramViewModel model)
        {
            SocialProgram socialProgram = new SocialProgram
            {
                DescriptionDe =  model.DescriptionDe,
                DescriptionFr =  model.DescriptionFr,
                NameDe = model.NameDe,
                NameFr = model.NameFr
            };
            socialProgram.Order = _socialProgramsRepository.GetAll().Select(b => b.Order).DefaultIfEmpty(0).Max() + 1;
            _socialProgramsRepository.Add(socialProgram);
            SafeSocialProgramImages(model, socialProgram);
            _socialProgramsRepository.Update(socialProgram);
            return CreatedAtRoute(GetSocialProgramRouteName, new {id = socialProgram.Id}, socialProgram);
        }

        // PUT: api/SocialPrograms/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromForm] SocialProgramViewModel model)
        {
            var existingSocialProgram = _socialProgramsRepository.Get(id);
            if (existingSocialProgram == null)
            {
                return NotFound();
            }

            existingSocialProgram.NameDe = model.NameDe;
            existingSocialProgram.NameFr = model.NameFr;
            existingSocialProgram.DescriptionDe = model.DescriptionDe;
            existingSocialProgram.DescriptionFr = model.DescriptionFr;
            existingSocialProgram.Order = model.Order ?? existingSocialProgram.Order;

            SafeSocialProgramImages(model, existingSocialProgram);

            _socialProgramsRepository.Update(existingSocialProgram);

            return NoContent();
        }

        [HttpPut("{firstId:int}/{secondId:int}"), Authorize]
        public IActionResult Put(int firstId, int secondId)
        {
            var existingSocialProgram1 = _socialProgramsRepository.Get(firstId);
            var existingSocialProgram2 = _socialProgramsRepository.Get(secondId);
            if (existingSocialProgram1 == null || existingSocialProgram2 == null)
            {
                return NotFound();
            }

            int tmpOrder = existingSocialProgram1.Order;
            existingSocialProgram1.Order = existingSocialProgram2.Order;
            existingSocialProgram2.Order = tmpOrder;
            _socialProgramsRepository.Update(existingSocialProgram1);
            _socialProgramsRepository.Update(existingSocialProgram2);

            return NoContent();
        }

        // DELETE: api/SocialPrograms/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var existingSocialProgram = _socialProgramsRepository.Get(id);
            if (existingSocialProgram == null)
            {
                return NotFound();
            }

            _socialProgramsRepository.Delete(existingSocialProgram);

            return NoContent();
        }

        private void SafeSocialProgramImages(SocialProgramViewModel model, SocialProgram socialProgram)
        {
            if (model.ImageThumbnail != null)
            {
                string filename = socialProgram.Id + Path.GetExtension(model.ImageThumbnail.FileName);
                _fileUtility.SaveImage(model.ImageThumbnail.OpenReadStream(), "socialPrograms", "thumbnail", filename,
                    new Size(_configuration.GetValue<int>("Images:ThumbnailSize:SocialPrograms:X"),
                        _configuration.GetValue<int>("Images:ThumbnailSize:SocialPrograms:Y")));
                socialProgram.ImageThumbnail = filename;
            }

            if (model.ImageLarge != null)
            {
                string filename = socialProgram.Id + Path.GetExtension(model.ImageLarge.FileName);
                _fileUtility.SaveImage(model.ImageLarge.OpenReadStream(), "socialPrograms", "images", filename,
                    new Size(_configuration.GetValue<int>("Images:SocialPrograms:X"),
                        _configuration.GetValue<int>("Images:SocialPrograms:Y")));
                socialProgram.ImageLarge = filename;
            }

            if (model.ImageMobile != null)
            {
                string filename = socialProgram.Id + Path.GetExtension(model.ImageMobile.FileName);
                _fileUtility.SaveImage(model.ImageMobile.OpenReadStream(), "socialPrograms", "mobile", filename,
                    new Size(_configuration.GetValue<int>("Images:MobileSize:SocialPrograms:X"),
                        _configuration.GetValue<int>("Images:MobileSize:SocialPrograms:Y")));
                socialProgram.ImageMobile = filename;
            }
        }
    }
}