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
    public class ReservaController : Controller
    {
        private readonly ProyectoW1Context _context;

        public ReservaController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var proyectoW1Context = _context.Reserva.Include(r => r.IdeventoNavigation).Include(r => r.IdusuarioNavigation);
            return View(await proyectoW1Context.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.IdeventoNavigation)
                .Include(r => r.IdusuarioNavigation)
                .SingleOrDefaultAsync(m => m.Idreserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento");
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idreserva,Idevento,Idusuario,Reserva1,Confirma")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", reserva.Idevento);
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", reserva.Idusuario);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.SingleOrDefaultAsync(m => m.Idreserva == id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", reserva.Idevento);
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", reserva.Idusuario);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idreserva,Idevento,Idusuario,Reserva1,Confirma")] Reserva reserva)
        {
            if (id != reserva.Idreserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Idreserva))
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
            ViewData["Idevento"] = new SelectList(_context.Evento, "Idevento", "Idevento", reserva.Idevento);
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", reserva.Idusuario);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.IdeventoNavigation)
                .Include(r => r.IdusuarioNavigation)
                .SingleOrDefaultAsync(m => m.Idreserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.SingleOrDefaultAsync(m => m.Idreserva == id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Idreserva == id);
        }
    }
}
