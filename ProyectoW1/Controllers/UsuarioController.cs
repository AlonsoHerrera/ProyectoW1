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
    public class UsuarioController : Controller
    {
        private readonly ProyectoW1Context _context;

        public UsuarioController(ProyectoW1Context context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var proyectoW1Context = _context.Usuario.Include(u => u.IdentidadNavigation).Include(u => u.IdnivelNavigation).Include(u => u.IdtipoNavigation);
            return View(await proyectoW1Context.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.IdentidadNavigation)
                .Include(u => u.IdnivelNavigation)
                .Include(u => u.IdtipoNavigation)
                .SingleOrDefaultAsync(m => m.Idusuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["Identidad"] = new SelectList(_context.Entidad, "Identidad", "Identidad");
            ViewData["Idnivel"] = new SelectList(_context.NivelAcademico, "Idnivel", "Idnivel");
            ViewData["Idtipo"] = new SelectList(_context.TipoUsuario, "Idtipo", "Idtipo");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idusuario,Idtipo,Nombre,Apellido1,Apellido2,Usuario1,Clave,FechaIngreso,Estado,Identidad,Idnivel")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Identidad"] = new SelectList(_context.Entidad, "Identidad", "Identidad", usuario.Identidad);
            ViewData["Idnivel"] = new SelectList(_context.NivelAcademico, "Idnivel", "Idnivel", usuario.Idnivel);
            ViewData["Idtipo"] = new SelectList(_context.TipoUsuario, "Idtipo", "Idtipo", usuario.Idtipo);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.SingleOrDefaultAsync(m => m.Idusuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["Identidad"] = new SelectList(_context.Entidad, "Identidad", "Identidad", usuario.Identidad);
            ViewData["Idnivel"] = new SelectList(_context.NivelAcademico, "Idnivel", "Idnivel", usuario.Idnivel);
            ViewData["Idtipo"] = new SelectList(_context.TipoUsuario, "Idtipo", "Idtipo", usuario.Idtipo);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idusuario,Idtipo,Nombre,Apellido1,Apellido2,Usuario1,Clave,FechaIngreso,Estado,Identidad,Idnivel")] Usuario usuario)
        {
            if (id != usuario.Idusuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Idusuario))
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
            ViewData["Identidad"] = new SelectList(_context.Entidad, "Identidad", "Identidad", usuario.Identidad);
            ViewData["Idnivel"] = new SelectList(_context.NivelAcademico, "Idnivel", "Idnivel", usuario.Idnivel);
            ViewData["Idtipo"] = new SelectList(_context.TipoUsuario, "Idtipo", "Idtipo", usuario.Idtipo);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.IdentidadNavigation)
                .Include(u => u.IdnivelNavigation)
                .Include(u => u.IdtipoNavigation)
                .SingleOrDefaultAsync(m => m.Idusuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.SingleOrDefaultAsync(m => m.Idusuario == id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Idusuario == id);
        }
    }
}
