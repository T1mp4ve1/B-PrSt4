using Microsoft.AspNetCore.Mvc;

namespace Prigione.Controllers
{
    public class VerbaliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
