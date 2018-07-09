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
    public class NivelAcademicoController : Controller
    {
        private readonly ProyectoW1Context _context;

        public NivelAcademicoController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: NivelAcademico
        public async Task<IActionResult> Index()
        {
            return View(await _context.NivelAcademico.ToListAsync());
        }

        // GET: NivelAcademico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelAcademico = await _context.NivelAcademico
                .SingleOrDefaultAsync(m => m.Idnivel == id);
            if (nivelAcademico == null)
            {
                return NotFound();
            }

            return View(nivelAcademico);
        }

        // GET: NivelAcademico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelAcademico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnivel,Descripcion")] NivelAcademico nivelAcademico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelAcademico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelAcademico);
        }

        // GET: NivelAcademico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelAcademico = await _context.NivelAcademico.SingleOrDefaultAsync(m => m.Idnivel == id);
            if (nivelAcademico == null)
            {
                return NotFound();
            }
            return View(nivelAcademico);
        }

        // POST: NivelAcademico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnivel,Descripcion")] NivelAcademico nivelAcademico)
        {
            if (id != nivelAcademico.Idnivel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelAcademico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelAcademicoExists(nivelAcademico.Idnivel))
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
            return View(nivelAcademico);
        }

        // GET: NivelAcademico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelAcademico = await _context.NivelAcademico
                .SingleOrDefaultAsync(m => m.Idnivel == id);
            if (nivelAcademico == null)
            {
                return NotFound();
            }

            return View(nivelAcademico);
        }

        // POST: NivelAcademico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nivelAcademico = await _context.NivelAcademico.SingleOrDefaultAsync(m => m.Idnivel == id);
            _context.NivelAcademico.Remove(nivelAcademico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelAcademicoExists(int id)
        {
            return _context.NivelAcademico.Any(e => e.Idnivel == id);
        }
    }
}
