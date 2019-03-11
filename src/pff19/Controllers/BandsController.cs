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
    public class BandsController : ApiControllerBase
    {
        private const string GetBandRouteName = "GetBands";
        private readonly BandRepository _bandRepository;
        private readonly IConfiguration _configuration;
        private readonly FileUtility _fileUtility;

        public BandsController(BandRepository bandRepository, IConfiguration configuration, FileUtility fileUtility)
        {
            _bandRepository = bandRepository;
            _configuration = configuration;
            _fileUtility = fileUtility;
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
        public IActionResult Post([FromForm] BandViewModel model)
        {
            Band band = new Band
            {
                DescriptionDe =  model.DescriptionDe,
                DescriptionFr =  model.DescriptionFr,
                Name = model.Name,
                SpotifyPlaylist = model.SpotifyPlaylist,
                YoutubeUrls = model.YoutubeUrls,
                Facebook =  model.Facebook,
                Instagram = model.Instagram,
                PlayTime = model.PlayTime,
                WebSiteUrl = model.WebSiteUrl
            };
            band.Order = _bandRepository.GetAll().Select(b => b.Order).DefaultIfEmpty(0).Max() + 1;
            _bandRepository.Add(band);
            SafeBandImages(model, band);
            _bandRepository.Update(band);
            return CreatedAtRoute(GetBandRouteName, new {id = band.Id}, band);
        }

        // PUT: api/Bands/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromForm] BandViewModel model)
        {
            var existingBand = _bandRepository.Get(id);
            if (existingBand == null)
            {
                return NotFound();
            }

            existingBand.Name = model.Name;
            existingBand.DescriptionDe = model.DescriptionDe;
            existingBand.DescriptionFr = model.DescriptionFr;
            existingBand.Name = model.Name;
            existingBand.SpotifyPlaylist = model.SpotifyPlaylist;
            existingBand.YoutubeUrls = model.YoutubeUrls;
            existingBand.Order = model.Order ?? existingBand.Order;
            existingBand.Facebook = model.Facebook;
            existingBand.Instagram = model.Instagram;
            existingBand.PlayTime = model.PlayTime;
            existingBand.WebSiteUrl = model.WebSiteUrl;

            SafeBandImages(model, existingBand);

            _bandRepository.Update(existingBand);

            return NoContent();
        }

        [HttpPut("{firstId:int}/{secondId:int}"), Authorize]
        public IActionResult Put(int firstId, int secondId)
        {
            var existingBand1 = _bandRepository.Get(firstId);
            var existingBand2 = _bandRepository.Get(secondId);
            if (existingBand1 == null || existingBand2 == null)
            {
                return NotFound();
            }

            int tmpOrder = existingBand1.Order;
            existingBand1.Order = existingBand2.Order;
            existingBand2.Order = tmpOrder;
            _bandRepository.Update(existingBand1);
            _bandRepository.Update(existingBand2);

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

        private void SafeBandImages(BandViewModel model, Band band)
        {
            if (model.ImageThumbnail != null)
            {
                string filename = band.Id + Path.GetExtension(model.ImageThumbnail.FileName);
                _fileUtility.SaveImage(model.ImageThumbnail.OpenReadStream(), "bands", "thumbnail", filename,
                    new Size(_configuration.GetValue<int>("Images:ThumbnailSize:Bands:X"),
                        _configuration.GetValue<int>("Images:ThumbnailSize:Bands:Y")));
                band.ImageThumbnail = filename;
            }

            if (model.ImageLarge != null)
            {
                string filename = band.Id + Path.GetExtension(model.ImageLarge.FileName);
                _fileUtility.SaveImage(model.ImageLarge.OpenReadStream(), "bands", "images", filename,
                    new Size(_configuration.GetValue<int>("Images:Bands:X"),
                        _configuration.GetValue<int>("Images:Bands:Y")));
                band.ImageLarge = filename;
            }
        }
    }
}