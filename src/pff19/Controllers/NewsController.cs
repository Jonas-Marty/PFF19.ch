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
                TitleFr = model.TitleFr
            };

            _newsRepository.Add(news);

            SafeNewsImage(model, news);

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

            SafeNewsImage(model, existingNews);

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

        private void SafeNewsImage(NewsViewModel model, News existingNews)
        {
            if (model.UploadImage != null)
            {
                string filename = existingNews.Id + Path.GetExtension(model.UploadImage.FileName);
                Size thumbnailSize = new Size(_configuration.GetValue<int>("Images:ThumbnailSize:News:X"), _configuration.GetValue<int>("Images:ThumbnailSize:News:Y"));
                _fileUtility.SaveImage(model.UploadImage, "news", filename, thumbnailSize);
                existingNews.Image = filename;
            }
        }
    }
}
