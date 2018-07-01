using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pff.DataAccess.Models;
using pff.DataAccess.Repositories;

namespace pff19.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : Controller
    {
        private readonly SponsorRepository _sponsorRepository;

        public SponsorController(SponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        [HttpGet]
        public ActionResult<List<Sponsor>> Get()
        {
            return _sponsorRepository.GetSponsors().ToList();
        }
    }
}
