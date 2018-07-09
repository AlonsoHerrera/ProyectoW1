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
    public class UbicacionController : Controller
    {
        private readonly ProyectoW1Context _context;

        public UbicacionController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Ubicacion
        public async Task<IActionResult> Index()
        {
            var proyectoW1Context = _context.Ubicacion.Include(u => u.IdcantonNavigation).Include(u => u.IddistritoNavigation).Include(u => u.IdeventoNavigation).Include(u => u.IdprovinciaNavigation);
            return View(await proyectoW1Context.ToListAsync());
        }

        // GET: Ubicacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion
                .Include(u => u.IdcantonNavigation)
                .Include(u => u.IddistritoNavigation)
                .Include(u => u.IdeventoNavigation)
                .Include(u => u.IdprovinciaNavigation)
                .SingleOrDefaultAsync(m => m.Idubicacion == id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return View(ubicacion);
        }

        // GET: Ubicacion/Create
        public IActionResult Create()
        {
            ViewData["Idcanton"] = new SelectList(_context.Canton, "Idcanton", "Idcanton");
            ViewData["Iddistrito"] = new SelectList(_context.Distrito, "Iddistrito", "Iddistrito");
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento");
            ViewData["Idprovincia"] = new SelectList(_context.Provincia, "Idprovincia", "Idprovincia");
            return View();
        }

        // POST: Ubicacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idubicacion,Idevento,Idprovincia,Idcanton,Iddistrito,Lugar")] Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcanton"] = new SelectList(_context.Canton, "Idcanton", "Idcanton", ubicacion.Idcanton);
            ViewData["Iddistrito"] = new SelectList(_context.Distrito, "Iddistrito", "Iddistrito", ubicacion.Iddistrito);
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", ubicacion.Idevento);
            ViewData["Idprovincia"] = new SelectList(_context.Provincia, "Idprovincia", "Idprovincia", ubicacion.Idprovincia);
            return View(ubicacion);
        }

        // GET: Ubicacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion.SingleOrDefaultAsync(m => m.Idubicacion == id);
            if (ubicacion == null)
            {
                return NotFound();
            }
            ViewData["Idcanton"] = new SelectList(_context.Canton, "Idcanton", "Idcanton", ubicacion.Idcanton);
            ViewData["Iddistrito"] = new SelectList(_context.Distrito, "Iddistrito", "Iddistrito", ubicacion.Iddistrito);
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", ubicacion.Idevento);
            ViewData["Idprovincia"] = new SelectList(_context.Provincia, "Idprovincia", "Idprovincia", ubicacion.Idprovincia);
            return View(ubicacion);
        }

        // POST: Ubicacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idubicacion,Idevento,Idprovincia,Idcanton,Iddistrito,Lugar")] Ubicacion ubicacion)
        {
            if (id != ubicacion.Idubicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacionExists(ubicacion.Idubicacion))
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
            ViewData["Idcanton"] = new SelectList(_context.Canton, "Idcanton", "Idcanton", ubicacion.Idcanton);
            ViewData["Iddistrito"] = new SelectList(_context.Distrito, "Iddistrito", "Iddistrito", ubicacion.Iddistrito);
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", ubicacion.Idevento);
            ViewData["Idprovincia"] = new SelectList(_context.Provincia, "Idprovincia", "Idprovincia", ubicacion.Idprovincia);
            return View(ubicacion);
        }

        // GET: Ubicacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion
                .Include(u => u.IdcantonNavigation)
                .Include(u => u.IddistritoNavigation)
                .Include(u => u.IdeventoNavigation)
                .Include(u => u.IdprovinciaNavigation)
                .SingleOrDefaultAsync(m => m.Idubicacion == id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return View(ubicacion);
        }

        // POST: Ubicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ubicacion = await _context.Ubicacion.SingleOrDefaultAsync(m => m.Idubicacion == id);
            _context.Ubicacion.Remove(ubicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionExists(int id)
        {
            return _context.Ubicacion.Any(e => e.Idubicacion == id);
        }
    }
}
