using Microsoft.AspNetCore.Mvc;

namespace pff19.Controllers
{
    public class HomeController : ApiControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
