using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prigione.Data;

namespace Prigione.Controllers
{
    public class _ReportController : Controller
    {
        private readonly PrigioneDbContext _db;

        public _ReportController(PrigioneDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // 1) Totale dei verbali per trasgressore
        public async Task<IActionResult> VerbaliPerTrasgressore()
        {
            var result = await _db.VerbaliTest
                .Include(v => v.Trasgressore)
                .GroupBy(v => new { v.TrasgressoreID, v.Trasgressore.Nome, v.Trasgressore.Cognome })
                .Select(g => new
                {
                    Trasgressore = g.Key.Nome + " " + g.Key.Cognome,
                    TotaleVerbali = g.Count()
                })
                .ToListAsync();

            return View(result);
        }

        // 2) Totale punti decurtati per trasgressore
        public async Task<IActionResult> PuntiDecurtatiPerTrasgressore()
        {
            var result = await _db.VerbaliTest
                .Include(v => v.Trasgressore)
                .GroupBy(v => new { v.TrasgressoreID, v.Trasgressore.Nome, v.Trasgressore.Cognome })
                .Select(g => new
                {
                    Trasgressore = g.Key.Nome + " " + g.Key.Cognome,
                    TotalePunti = g.Sum(v => v.DecurtamentoPunti)
                })
                .ToListAsync();

            return View(result);
        }

        // 3) Violazioni con punti decurtati > 10
        public async Task<IActionResult> ViolazioniPuntiSuperiori()
        {
            var result = await _db.VerbaliTest
                .Include(v => v.Trasgressore)
                .Where(v => v.DecurtamentoPunti > 10)
                .Select(v => new
                {
                    v.Importo,
                    Nome = v.Trasgressore.Nome,
                    Cognome = v.Trasgressore.Cognome,
                    v.DataViolazione,
                    v.DecurtamentoPunti
                })
                .ToListAsync();

            return View(result);
        }

        // 4) Violazioni con importo > 400
        public async Task<IActionResult> ViolazioniImportoAlto()
        {
            var result = await _db.VerbaliTest
                .Include(v => v.Trasgressore)
                .Where(v => v.Importo > 400)
                .Select(v => new
                {
                    v.Importo,
                    Nome = v.Trasgressore.Nome,
                    Cognome = v.Trasgressore.Cognome,
                    v.DataViolazione,
                    v.DecurtamentoPunti
                })
                .ToListAsync();

            return View(result);
        }
    }
}
