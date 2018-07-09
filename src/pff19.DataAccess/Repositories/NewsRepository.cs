using System;
using System.Collections.Generic;
using System.Text;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class NewsRepository
    {
        private readonly PffContext _context;

        public NewsRepository(PffContext context)
        {
            _context = context;
        }

        public IEnumerable<News> GetAll()
        {
            return _context.News;
        }

        public News Get(int id)
        {
            return _context.News.Find(id);
        }

        public News Add(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
            return news;
        }

        public void Update(News existingNews)
        {
            _context.News.Update(existingNews);
            _context.SaveChanges();
        }

        public void Delete(News newsToDelete)
        {
            _context.News.Remove(newsToDelete);
            _context.SaveChanges();
        }
    }
}
