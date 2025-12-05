using Microsoft.AspNetCore.Mvc;

namespace Prigione.Controllers
{
    public class TrasgressoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
