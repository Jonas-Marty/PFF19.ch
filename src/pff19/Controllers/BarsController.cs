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
    public class BarsController : ApiControllerBase
    {
        private const string GetBarRouteName = "GetBars";
        private readonly BarsRepository _barsRepository;
        private readonly IConfiguration _configuration;
        private readonly FileUtility _fileUtility;

        public BarsController(BarsRepository barsRepository, IConfiguration configuration, FileUtility fileUtility)
        {
            _barsRepository = barsRepository;
            _configuration = configuration;
            _fileUtility = fileUtility;
        }

        // GET: api/Bars
        [HttpGet]
        public ActionResult<IEnumerable<Bar>> Get()
        {
            return _barsRepository.GetAll().ToList();
        }

        // GET: api/Bars/5
        [HttpGet("{id}", Name = GetBarRouteName)]
        public Bar Get(int id)
        {
            return _barsRepository.Get(id);
        }

        // POST: api/Bars
        [HttpPost]
        public IActionResult Post([FromForm] BarViewModel model)
        {
            Bar bar = new Bar
            {
                DescriptionDe =  model.DescriptionDe,
                DescriptionFr =  model.DescriptionFr,
                NameDe = model.NameDe,
                NameFr = model.NameFr,
            };
            bar.Order = _barsRepository.GetAll().Select(b => b.Order).DefaultIfEmpty(0).Max() + 1;
            _barsRepository.Add(bar);
            SafeBarImages(model, bar);
            _barsRepository.Update(bar);
            return CreatedAtRoute(GetBarRouteName, new {id = bar.Id}, bar);
        }

        // PUT: api/Bars/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromForm] BarViewModel model)
        {
            var existingBar = _barsRepository.Get(id);
            if (existingBar == null)
            {
                return NotFound();
            }

            existingBar.NameDe = model.NameDe;
            existingBar.NameFr = model.NameFr;
            existingBar.DescriptionDe = model.DescriptionDe;
            existingBar.DescriptionFr = model.DescriptionFr;
            existingBar.Order = model.Order ?? existingBar.Order;

            SafeBarImages(model, existingBar);

            _barsRepository.Update(existingBar);

            return NoContent();
        }

        [HttpPut("{firstId:int}/{secondId:int}"), Authorize]
        public IActionResult Put(int firstId, int secondId)
        {
            var existingBar1 = _barsRepository.Get(firstId);
            var existingBar2 = _barsRepository.Get(secondId);
            if (existingBar1 == null || existingBar2 == null)
            {
                return NotFound();
            }

            int tmpOrder = existingBar1.Order;
            existingBar1.Order = existingBar2.Order;
            existingBar2.Order = tmpOrder;
            _barsRepository.Update(existingBar1);
            _barsRepository.Update(existingBar2);

            return NoContent();
        }

        // DELETE: api/Bars/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var existingBar = _barsRepository.Get(id);
            if (existingBar == null)
            {
                return NotFound();
            }

            _barsRepository.Delete(existingBar);

            return NoContent();
        }

        private void SafeBarImages(BarViewModel model, Bar bar)
        {
            if (model.ImageThumbnail != null)
            {
                string filename = bar.Id + Path.GetExtension(model.ImageThumbnail.FileName);
                _fileUtility.SaveImage(model.ImageThumbnail.OpenReadStream(), "bars", "thumbnail", filename,
                    new Size(_configuration.GetValue<int>("Images:ThumbnailSize:Bars:X"),
                        _configuration.GetValue<int>("Images:ThumbnailSize:Bars:Y")));
                bar.ImageThumbnail = filename;
            }

            if (model.ImageLarge != null)
            {
                string filename = bar.Id + Path.GetExtension(model.ImageLarge.FileName);
                _fileUtility.SaveImage(model.ImageLarge.OpenReadStream(), "bars", "images", filename,
                    new Size(_configuration.GetValue<int>("Images:Bars:X"),
                        _configuration.GetValue<int>("Images:Bars:Y")));
                bar.ImageLarge = filename;
            }

            if (model.ImageMobile != null)
            {
                string filename = bar.Id + Path.GetExtension(model.ImageMobile.FileName);
                _fileUtility.SaveImage(model.ImageMobile.OpenReadStream(), "bars", "mobile", filename,
                    new Size(_configuration.GetValue<int>("Images:MobileSize:Bars:X"),
                        _configuration.GetValue<int>("Images:MobileSize:Bars:Y")));
                bar.ImageMobile = filename;
            }
        }
    }
}