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
    public class CantonController : Controller
    {
        private readonly ProyectoW1Context _context;

        public CantonController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Canton
        public async Task<IActionResult> Index()
        {
            return View(await _context.Canton.ToListAsync());
        }

        // GET: Canton/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton
                .SingleOrDefaultAsync(m => m.Idcanton == id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // GET: Canton/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Canton/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcanton,Idprovicia,CodCanton,Nombre")] Canton canton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canton);
        }

        // GET: Canton/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton.SingleOrDefaultAsync(m => m.Idcanton == id);
            if (canton == null)
            {
                return NotFound();
            }
            return View(canton);
        }

        // POST: Canton/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcanton,Idprovicia,CodCanton,Nombre")] Canton canton)
        {
            if (id != canton.Idcanton)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CantonExists(canton.Idcanton))
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
            return View(canton);
        }

        // GET: Canton/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton
                .SingleOrDefaultAsync(m => m.Idcanton == id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // POST: Canton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canton = await _context.Canton.SingleOrDefaultAsync(m => m.Idcanton == id);
            _context.Canton.Remove(canton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CantonExists(int id)
        {
            return _context.Canton.Any(e => e.Idcanton == id);
        }
    }
}
