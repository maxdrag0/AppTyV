using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTyV;
using AppTyV.Context;

namespace AppTyV.Controllers
{
    public class PartidoController : Controller
    {
        private readonly TyVDatabaseContext _context;

        public PartidoController(TyVDatabaseContext context)
        {
            _context = context;
        }

        // GET: Partido
        public async Task<IActionResult> Index()
        {
              return _context.Partidos != null ? 
                          View(await _context.Partidos.ToListAsync()) :
                          Problem("Entity set 'TyVDatabaseContext.Partidos'  is null.");
        }

        // GET: Partido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Partidos == null)
            {
                return NotFound();
            }

            var partido = await _context.Partidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // GET: Partido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lugar,Fecha,Hora,TotalJugadores,Tipo,Estado")] Partido partido)
        {
            if (ModelState.IsValid)
            {

                if (partido.TotalJugadores < 1 || partido.TotalJugadores > Partido.MaximoJugadores)
                {
                    ModelState.AddModelError("TotalJugadores", $"El número de jugadores debe estar entre 1 y {Partido.MaximoJugadores}.");
                    return View(partido);
                }

                if (_context.Partidos.Any(p => p.Fecha == partido.Fecha && p.Lugar == partido.Lugar))
                {
                    ModelState.AddModelError("Fecha", "Ya existe un partido en la misma fecha y lugar.");
                    return View(partido);
                }

                _context.Add(partido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partido);
        }

        // GET: Partido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Partidos == null)
            {
                return NotFound();
            }

            var partido = await _context.Partidos.FindAsync(id);
            if (partido == null)
            {
                return NotFound();
            }
            return View(partido);
        }

        // POST: Partido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lugar,Fecha,Hora,TotalJugadores,Tipo,Estado")] Partido partido)
        {
            if (id != partido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidoExists(partido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(partido);
        }

        // GET: Partido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Partidos == null)
            {
                return NotFound();
            }

            var partido = await _context.Partidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // POST: Partido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Partidos == null)
            {
                return Problem("Entity set 'TyVDatabaseContext.Partidos'  is null.");
            }
            var partido = await _context.Partidos.FindAsync(id);
            if (partido != null)
            {
                _context.Partidos.Remove(partido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidoExists(int id)
        {
          return (_context.Partidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
