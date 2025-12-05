using Microsoft.AspNetCore.Mvc;

namespace Prigione.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
