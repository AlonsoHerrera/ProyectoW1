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
    public class EventoController : Controller
    {
        private readonly ProyectoW1Context _context;

        public EventoController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Evento
        public async Task<IActionResult> Index()
        {
            var proyectoW1Context = _context.Evento.Include(e => e.IdexpositorNavigation).Include(e => e.IdtemaNavigation).Include(e => e.IdubicacionNavigation);
            return View(await proyectoW1Context.ToListAsync());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .Include(e => e.IdexpositorNavigation)
                .Include(e => e.IdtemaNavigation)
                .Include(e => e.IdubicacionNavigation)
                .SingleOrDefaultAsync(m => m.Idevento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            ViewData["Idexpositor"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario");
            ViewData["Idtema"] = new SelectList(_context.Tema, "Idtema", "Idtema");
            ViewData["Idubicacion"] = new SelectList(_context.Ubicacion, "Idubicacion", "Idubicacion");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idevento,IdtipoEvento,FechaInicio,FechaFinal,Idexpositor,Idtema,Limite,Estado,Calificacion,Idubicacion")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idexpositor"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", evento.Idexpositor);
            ViewData["Idtema"] = new SelectList(_context.Tema, "Idtema", "Idtema", evento.Idtema);
            ViewData["Idubicacion"] = new SelectList(_context.Ubicacion, "Idubicacion", "Idubicacion", evento.Idubicacion);
            return View(evento);
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.SingleOrDefaultAsync(m => m.Idevento == id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["Idexpositor"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", evento.Idexpositor);
            ViewData["Idtema"] = new SelectList(_context.Tema, "Idtema", "Idtema", evento.Idtema);
            ViewData["Idubicacion"] = new SelectList(_context.Ubicacion, "Idubicacion", "Idubicacion", evento.Idubicacion);
            return View(evento);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idevento,IdtipoEvento,FechaInicio,FechaFinal,Idexpositor,Idtema,Limite,Estado,Calificacion,Idubicacion")] Evento evento)
        {
            if (id != evento.Idevento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Idevento))
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
            ViewData["Idexpositor"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", evento.Idexpositor);
            ViewData["Idtema"] = new SelectList(_context.Tema, "Idtema", "Idtema", evento.Idtema);
            ViewData["Idubicacion"] = new SelectList(_context.Ubicacion, "Idubicacion", "Idubicacion", evento.Idubicacion);
            return View(evento);
        }

        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .Include(e => e.IdexpositorNavigation)
                .Include(e => e.IdtemaNavigation)
                .Include(e => e.IdubicacionNavigation)
                .SingleOrDefaultAsync(m => m.Idevento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Evento.SingleOrDefaultAsync(m => m.Idevento == id);
            _context.Evento.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.Idevento == id);
        }
    }
}
