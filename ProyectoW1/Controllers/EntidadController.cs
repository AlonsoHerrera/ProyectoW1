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
    public class EntidadController : Controller
    {
        private readonly ProyectoW1Context _context;

        public EntidadController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Entidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entidad.ToListAsync());
        }

        // GET: Entidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidad
                .SingleOrDefaultAsync(m => m.Identidad == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // GET: Entidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identidad,Descripcion,Estado")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entidad);
        }

        // GET: Entidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidad.SingleOrDefaultAsync(m => m.Identidad == id);
            if (entidad == null)
            {
                return NotFound();
            }
            return View(entidad);
        }

        // POST: Entidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identidad,Descripcion,Estado")] Entidad entidad)
        {
            if (id != entidad.Identidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadExists(entidad.Identidad))
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
            return View(entidad);
        }

        // GET: Entidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidad
                .SingleOrDefaultAsync(m => m.Identidad == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // POST: Entidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entidad = await _context.Entidad.SingleOrDefaultAsync(m => m.Identidad == id);
            _context.Entidad.Remove(entidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadExists(int id)
        {
            return _context.Entidad.Any(e => e.Identidad == id);
        }
    }
}
