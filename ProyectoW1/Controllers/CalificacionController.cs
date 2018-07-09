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
    public class CalificacionController : Controller
    {
        private readonly ProyectoW1Context _context;

        public CalificacionController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Calificacion
        public async Task<IActionResult> Index()
        {
            var proyectoW1Context = _context.Calificacion.Include(c => c.IdeventoNavigation).Include(c => c.IdusuarioNavigation);
            return View(await proyectoW1Context.ToListAsync());
        }

        // GET: Calificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacion
                .Include(c => c.IdeventoNavigation)
                .Include(c => c.IdusuarioNavigation)
                .SingleOrDefaultAsync(m => m.Idcalifiacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // GET: Calificacion/Create
        public IActionResult Create()
        {
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento");
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario");
            return View();
        }

        // POST: Calificacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcalifiacion,Idevento,Idusuario,Calificacion1,Comentario")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", calificacion.Idevento);
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", calificacion.Idusuario);
            return View(calificacion);
        }

        // GET: Calificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacion.SingleOrDefaultAsync(m => m.Idcalifiacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", calificacion.Idevento);
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", calificacion.Idusuario);
            return View(calificacion);
        }

        // POST: Calificacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcalifiacion,Idevento,Idusuario,Calificacion1,Comentario")] Calificacion calificacion)
        {
            if (id != calificacion.Idcalifiacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionExists(calificacion.Idcalifiacion))
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
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", calificacion.Idevento);
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", calificacion.Idusuario);
            return View(calificacion);
        }

        // GET: Calificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacion
                .Include(c => c.IdeventoNavigation)
                .Include(c => c.IdusuarioNavigation)
                .SingleOrDefaultAsync(m => m.Idcalifiacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacion = await _context.Calificacion.SingleOrDefaultAsync(m => m.Idcalifiacion == id);
            _context.Calificacion.Remove(calificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificacion.Any(e => e.Idcalifiacion == id);
        }
    }
}
