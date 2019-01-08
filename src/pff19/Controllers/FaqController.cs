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

        // GET: api/faq
        [HttpGet]
        public ActionResult<IEnumerable<Faq>> Get()
        {
            return _faqRepository.GetAll().ToList();
        }

        // GET: api/FAQ/5
        [HttpGet("{id}", Name = GetFaqsRoutName)]
        public Faq Get(int id)
        {
            return _faqRepository.Get(id);
        }

        // POST: api/Faq
        [HttpPost, Authorize]
        public IActionResult Post([FromForm]Faq faqs)
        {
            var order = _faqRepository.GetAll().Select(x => x.Order).DefaultIfEmpty(0).Max() + 1;
            faqs.Order = order;
            _faqRepository.Add(faqs);
            return CreatedAtRoute(GetFaqsRoutName, new { id = faqs.Id }, faqs);
        }

        [HttpPut("{firstId:int}/{secondId:int}"), Authorize]
        public IActionResult Put(int firstId, int secondId)
        {
            var existingFaq1 = _faqRepository.Get(firstId);
            var existingFaq2 = _faqRepository.Get(secondId);
            if (existingFaq1 == null || existingFaq2 == null)
            {
                return NotFound();
            }

            int tmpOrder = existingFaq1.Order;
            existingFaq1.Order = existingFaq2.Order;
            existingFaq2.Order = tmpOrder;
            _faqRepository.Update(existingFaq1);
            _faqRepository.Update(existingFaq2);

            return NoContent();
        }

        // PUT: api/News/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromForm]Faq faq)
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
        [HttpDelete("{id}"), Authorize]
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
