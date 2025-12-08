using Microsoft.AspNetCore.Mvc;
using Prigione.Models;
using Prigione.Services;

namespace Prigione.Controllers
{
    public class VerbaleModelTestController : Controller
    {
        private readonly IVerbaleModelTestService _service;
        private readonly IViolazioneService _violazione;
        private readonly ITrasgressoreService _trasgressore;
        public VerbaleModelTestController(IVerbaleModelTestService service, IViolazioneService violazione, ITrasgressoreService trasgressore)
        {
            _service = service;
            _violazione = violazione;
            _trasgressore = trasgressore;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(VerbaleModelTest verbal)
        {
            await _service.CreateAsync(verbal);
            ViewBag.Violazioni = await _violazione.GetAllAsync();
            ViewBag.Trasgressori = await _trasgressore.GetAllAsync();
            return RedirectToAction(nameof(Index));
        }


        //READ
        public async Task<IActionResult> Index()
        {
            var verbali = await _service.GetAllAsync();
            var violazioni = await _violazione.GetAllAsync();
            var trasgressori = await _trasgressore.GetAllAsync();
            ViewBag.Trasgressori = trasgressori;
            ViewBag.Violazioni = violazioni;
            return View(verbali);
        }

        //UPDATE
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var verbale = await _service.GetByIdAsync(id);
            var violazioni = await _violazione.GetAllAsync();
            var trasgressori = await _trasgressore.GetAllAsync();
            ViewBag.Trasgressori = trasgressori;
            ViewBag.Violazioni = violazioni;
            return View(verbale);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VerbaleModelTest verbale)
        {
            await _service.UpdateAsync(verbale);
            return RedirectToAction(nameof(Index));
        }

        //DELETE
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
