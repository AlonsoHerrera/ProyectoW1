using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoW1.DBModels;

namespace ProyectoW1.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly ProyectoW1Context _context;

        public TipoEventoController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: TipoEvento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEvento.ToListAsync());
        }

        // GET: TipoEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .SingleOrDefaultAsync(m => m.Idevento == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // GET: TipoEvento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEvento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idevento,Descripcion,Estado")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEvento);
        }

        // GET: TipoEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento.SingleOrDefaultAsync(m => m.Idevento == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEvento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idevento,Descripcion,Estado")] TipoEvento tipoEvento)
        {
            if (id != tipoEvento.Idevento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEventoExists(tipoEvento.Idevento))
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
            return View(tipoEvento);
        }

        // GET: TipoEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .SingleOrDefaultAsync(m => m.Idevento == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // POST: TipoEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEvento = await _context.TipoEvento.SingleOrDefaultAsync(m => m.Idevento == id);
            _context.TipoEvento.Remove(tipoEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEventoExists(int id)
        {
            return _context.TipoEvento.Any(e => e.Idevento == id);
        }
    }
}
