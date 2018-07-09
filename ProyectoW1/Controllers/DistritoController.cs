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
    public class DistritoController : Controller
    {
        private readonly ProyectoW1Context _context;

        public DistritoController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Distrito
        public async Task<IActionResult> Index()
        {
            return View(await _context.Distrito.ToListAsync());
        }

        // GET: Distrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito
                .SingleOrDefaultAsync(m => m.Iddistrito == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }

        // GET: Distrito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Distrito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddistrito,Idprovicia,Idcanton,CodDistrito,Nombre")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distrito);
        }

        // GET: Distrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito.SingleOrDefaultAsync(m => m.Iddistrito == id);
            if (distrito == null)
            {
                return NotFound();
            }
            return View(distrito);
        }

        // POST: Distrito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddistrito,Idprovicia,Idcanton,CodDistrito,Nombre")] Distrito distrito)
        {
            if (id != distrito.Iddistrito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistritoExists(distrito.Iddistrito))
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
            return View(distrito);
        }

        // GET: Distrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito
                .SingleOrDefaultAsync(m => m.Iddistrito == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }

        // POST: Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distrito = await _context.Distrito.SingleOrDefaultAsync(m => m.Iddistrito == id);
            _context.Distrito.Remove(distrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistritoExists(int id)
        {
            return _context.Distrito.Any(e => e.Iddistrito == id);
        }
    }
}
