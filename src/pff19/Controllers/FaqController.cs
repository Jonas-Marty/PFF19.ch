using System;
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
    public class FaqController : ApiControllerBase
    {
        private const string GetFaqsRoutName = "GetFaqs";
        private readonly FaqsRepository _faqRepository;

        public FaqController(FaqsRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        // GET: api/Faqs
        [HttpGet("top")]
        public ActionResult<IEnumerable<Faq>> Get()
        {
            return _faqRepository.GetAll().ToList();
        }

        // GET: api/News/5
        [HttpGet("{id}", Name = GetFaqsRoutName)]
        public Faq Get(int id)
        {
            return _faqRepository.Get(id);
        }

        // POST: api/Faqs
        [Authorize]
        [HttpPost]
        public IActionResult Post(Faq faqs)
        {
            _faqRepository.Add(faqs);
            return CreatedAtRoute(GetFaqsRoutName, new { id = faqs.Id }, faqs);
        }

        // PUT: api/News/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Faq faq)
        {
            var existingFaq = _faqRepository.Get(id);
            if (existingFaq == null)
            {
                return NotFound();
            }

            existingFaq.AnswerDe = faq.AnswerDe;
            existingFaq.AnswerFr = faq.AnswerFr;
            existingFaq.Category = faq.Category;
            existingFaq.Order = faq.Order;
            existingFaq.QuestionDe = faq.QuestionDe;
            existingFaq.QuestionFr = faq.QuestionFr;

            _faqRepository.Update(existingFaq);

            return NoContent();
        }

        // DELETE: api/faq/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingFaq = _faqRepository.Get(id);
            if (existingFaq == null)
            {
                return NotFound();
            }

            _faqRepository.Delete(existingFaq);

            return NoContent();
        }
    }
}
