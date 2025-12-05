using Microsoft.AspNetCore.Mvc;
using Prigione.Models;
using Prigione.Services;

namespace Prigione.Controllers
{
    public class TrasgressoriController : Controller
    {
        private readonly ITrasgressoreService _service;
        public TrasgressoriController(ITrasgressoreService service)
        {
            _service = service;
        }
        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(TrasgressoreModel trasgressore)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(trasgressore);
                return RedirectToAction(nameof(Index));
            }
            return View(trasgressore);
        }


        //READ
        public async Task<IActionResult> Index()
        {
            var trasgressori = await _service.GetAllAsync();
            return View(trasgressori);
        }
    }
}
