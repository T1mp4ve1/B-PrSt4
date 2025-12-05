using Microsoft.AspNetCore.Mvc;
using Prigione.Models;
using Prigione.Services;

namespace Prigione.Controllers
{
    public class ViolazioniController : Controller
    {
        private readonly IViolazioneService _service;
        public ViolazioniController(IViolazioneService service)
        {
            _service = service;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(ViolazioneModel violazione)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(violazione);
                return RedirectToAction(nameof(Index));
            }

            return View("Index", violazione);
        }


        //READ
        public async Task<IActionResult> Index()
        {
            var violazioni = await _service.GetAllAsync();
            return View(violazioni);
        }
    }
}
