using System.Collections.Generic;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class SocialProgramsRepository
    {
        private readonly PffContext _context;

        public SocialProgramsRepository(PffContext context)
        {
            _context = context;
        }
        public IEnumerable<SocialProgram> GetAll()
        {
            return _context.SocialPrograms;
        }

        public SocialProgram Get(int id)
        {
            return _context.SocialPrograms.Find(id);
        }

        public SocialProgram Add(SocialProgram socialProgram)
        {
            _context.SocialPrograms.Add(socialProgram);
            _context.SaveChanges();
            return socialProgram;
        }

        public void Update(SocialProgram existingSocialProgram)
        {
            _context.SocialPrograms.Update(existingSocialProgram);
            _context.SaveChanges();
        }

        public void Delete(SocialProgram socialProgramToDelete)
        {
            _context.SocialPrograms.Remove(socialProgramToDelete);
            _context.SaveChanges();
        }
    }
}
