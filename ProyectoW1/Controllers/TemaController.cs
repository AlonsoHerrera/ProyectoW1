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
    public class TemaController : Controller
    {
        private readonly ProyectoW1Context _context;

        public TemaController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Tema
        public async Task<IActionResult> Index()
        {
            var proyectoW1Context = _context.Tema.Include(t => t.IdtipoNavigation);
            return View(await proyectoW1Context.ToListAsync());
        }

        // GET: Tema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Tema
                .Include(t => t.IdtipoNavigation)
                .SingleOrDefaultAsync(m => m.Idtema == id);
            if (tema == null)
            {
                return NotFound();
            }

            return View(tema);
        }

        // GET: Tema/Create
        public IActionResult Create()
        {
            ViewData["Idtipo"] = new SelectList(_context.TipoEvento, "Idevento", "Idevento");
            return View();
        }

        // POST: Tema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtema,Idtipo,Descripcion")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtipo"] = new SelectList(_context.TipoEvento, "Idevento", "Idevento", tema.Idtipo);
            return View(tema);
        }

        // GET: Tema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Tema.SingleOrDefaultAsync(m => m.Idtema == id);
            if (tema == null)
            {
                return NotFound();
            }
            ViewData["Idtipo"] = new SelectList(_context.TipoEvento, "Idevento", "Idevento", tema.Idtipo);
            return View(tema);
        }

        // POST: Tema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtema,Idtipo,Descripcion")] Tema tema)
        {
            if (id != tema.Idtema)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemaExists(tema.Idtema))
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
            ViewData["Idtipo"] = new SelectList(_context.TipoEvento, "Idevento", "Idevento", tema.Idtipo);
            return View(tema);
        }

        // GET: Tema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Tema
                .Include(t => t.IdtipoNavigation)
                .SingleOrDefaultAsync(m => m.Idtema == id);
            if (tema == null)
            {
                return NotFound();
            }

            return View(tema);
        }

        // POST: Tema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tema = await _context.Tema.SingleOrDefaultAsync(m => m.Idtema == id);
            _context.Tema.Remove(tema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemaExists(int id)
        {
            return _context.Tema.Any(e => e.Idtema == id);
        }
    }
}
