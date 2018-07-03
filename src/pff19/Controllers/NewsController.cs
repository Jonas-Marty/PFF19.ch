using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;

namespace pff19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private const string GetNewsRoutName = "GetNews";
        private readonly NewsRepository _newsRepository;

        public NewsController(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        // GET: api/News
        [HttpGet]
        public ActionResult<IEnumerable<News>> Get()
        {
            return _newsRepository.GetAll().ToList();
        }

        // GET: api/News/5
        [HttpGet("{id}", Name = GetNewsRoutName)]
        public News Get(int id)
        {
            return _newsRepository.Get(id);
        }

        // POST: api/News
        [HttpPost]
        public IActionResult Post(News news)
        {
            _newsRepository.Add(news);
            return CreatedAtRoute(GetNewsRoutName, new { id = news.Id }, news);
        }

        // PUT: api/News/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, News news)
        {
            var existingNews = _newsRepository.Get(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            existingNews.Content = news.Content;
            existingNews.Date = news.Date;
            existingNews.Image = news.Image;
            existingNews.Title = news.Title;

            _newsRepository.Update(existingNews);

            return NoContent();
        }

        // DELETE: api/news/5
        [HttpDelete("{id}")]
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
    }
}
