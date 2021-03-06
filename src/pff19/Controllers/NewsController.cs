using System;
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
    public class NewsController : ApiControllerBase
    {
        private const string GetNewsRoutName = "GetNews";
        private readonly NewsRepository _newsRepository;
        private readonly IConfiguration _configuration;
        private readonly FileUtility _fileUtility;

        public NewsController(NewsRepository newsRepository, IConfiguration configuration, FileUtility fileUtility)
        {
            _newsRepository = newsRepository;
            _configuration = configuration;
            _fileUtility = fileUtility;
        }

        // GET: api/News
        [HttpGet]
        public ActionResult<IEnumerable<News>> Get()
        {
            return _newsRepository.GetAll().ToList();
        }

        // GET: api/News
        [HttpGet("top")]
        public ActionResult<IEnumerable<News>> Top()
        {
            return _newsRepository.GetTop3News().ToArray();
        }

        // GET: api/News/5
        [HttpGet("{id}", Name = GetNewsRoutName)]
        public News Get(int id)
        {
            return _newsRepository.Get(id);
        }

        // POST: api/News
        [HttpPost, Authorize]
        public IActionResult Post([FromForm]NewsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            News news = new News
            {
                ContentDe = model.ContentDe,
                ContentFr = model.ContentFr,
                Date = model.Date,
                PreviewDe = model.PreviewDe,
                PreviewFr = model.PreviewFr,
                TitleDe = model.TitleDe,
                TitleFr = model.TitleFr,
                LinkFacebook =  model.LinkFacebook,
                LinkInstagram =  model.LinkInstagram,
                DateCreated =  DateTime.Now
            };

            _newsRepository.Add(news);

            SafeNewsImages(model, news);

            _newsRepository.Update(news);

            return CreatedAtRoute(GetNewsRoutName, new { id = news.Id }, news);
        }

        // PUT: api/News/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromForm]NewsViewModel model)
        {
            var existingNews = _newsRepository.Get(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            existingNews.ContentDe = model.ContentDe;
            existingNews.ContentFr = model.ContentFr;
            existingNews.Date = model.Date;
            existingNews.TitleDe = model.TitleDe;
            existingNews.TitleFr = model.TitleFr;
            existingNews.PreviewFr = model.PreviewFr;
            existingNews.PreviewDe = model.PreviewDe;
            existingNews.LinkFacebook = model.LinkFacebook;
            existingNews.LinkInstagram = model.LinkInstagram;

            SafeNewsImages(model, existingNews);

            _newsRepository.Update(existingNews);

            return NoContent();
        }

        // DELETE: api/news/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var existingNews = _newsRepository.Get(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            _newsRepository.Delete(existingNews);

            return NoContent();
        }

        private void SafeNewsImages(NewsViewModel model, News existingNews)
        {
            if (model.Images != null && model.Images.Count > 0)
            {
                var thumbnailSize = new Size(_configuration.GetValue<int>("Images:ThumbnailSize:News:X"),
                    _configuration.GetValue<int>("Images:ThumbnailSize:News:Y"));
                var imageSize = new Size(_configuration.GetValue<int>("Images:News:X"),
                    _configuration.GetValue<int>("Images:News:Y"));

                var fileNames = new List<string>();
                for (var i = 0; i < model.Images.Count; i++)
                {
                    var uploadedImage = model.Images[i];
                    var filename = existingNews.Id + "_" + i + "_" + Path.GetExtension(uploadedImage.FileName);

                    using (Stream uploadStream = uploadedImage.OpenReadStream())
                    using (MemoryStream imageStream = new MemoryStream())
                    {
                        uploadStream.CopyTo(imageStream);
                        imageStream.Seek(0, SeekOrigin.Begin);
                        _fileUtility.SaveImage(imageStream, "news", "thumbnail", filename, thumbnailSize);
                        imageStream.Seek(0, SeekOrigin.Begin);
                        _fileUtility.SaveImage(imageStream, "news", "images", filename, imageSize);
                    }
                    fileNames.Add(filename);
                }

                existingNews.Images = string.Join(';', fileNames);
            }
        }
    }
}
