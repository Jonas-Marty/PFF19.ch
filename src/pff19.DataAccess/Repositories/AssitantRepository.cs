using System.Collections.Generic;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class AssistantRepository
    {
        private readonly PffContext _context;

        public AssistantRepository(PffContext context)
        {
            _context = context;
        }
        public IEnumerable<Assistant> GetAll()
        {
            return _context.Assistants;
        }

        public Assistant Get(int id)
        {
            return _context.Assistants.Find(id);
        }

        public Assistant Add(Assistant assistant)
        {
            _context.Assistants.Add(assistant);
            _context.SaveChanges();
            return assistant;
        }

        public void Update(Assistant existingAssistant)
        {
            _context.Assistants.Update(existingAssistant);
            _context.SaveChanges();
        }

        public void Delete(Assistant assistantToDelete)
        {
            _context.Assistants.Remove(assistantToDelete);
            _context.SaveChanges();
        }
    }
}
