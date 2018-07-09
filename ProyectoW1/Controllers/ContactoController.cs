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
    public class ContactoController : Controller
    {
        private readonly ProyectoW1Context _context;

        public ContactoController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Contacto
        public async Task<IActionResult> Index()
        {
            var proyectoW1Context = _context.Contacto.Include(c => c.IdusuarioNavigation);
            return View(await proyectoW1Context.ToListAsync());
        }

        // GET: Contacto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .Include(c => c.IdusuarioNavigation)
                .SingleOrDefaultAsync(m => m.Idcontacto == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contacto/Create
        public IActionResult Create()
        {
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario");
            return View();
        }

        // POST: Contacto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcontacto,TipoContacto,Identificador,Idusuario")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", contacto.Idusuario);
            return View(contacto);
        }

        // GET: Contacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.Idcontacto == id);
            if (contacto == null)
            {
                return NotFound();
            }
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", contacto.Idusuario);
            return View(contacto);
        }

        // POST: Contacto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcontacto,TipoContacto,Identificador,Idusuario")] Contacto contacto)
        {
            if (id != contacto.Idcontacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Idcontacto))
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
            ViewData["Idusuario"] = new SelectList(_context.Usuario, "Idusuario", "Idusuario", contacto.Idusuario);
            return View(contacto);
        }

        // GET: Contacto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .Include(c => c.IdusuarioNavigation)
                .SingleOrDefaultAsync(m => m.Idcontacto == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.Idcontacto == id);
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.Idcontacto == id);
        }
    }
}
