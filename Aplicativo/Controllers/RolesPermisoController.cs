using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicativo.Models;

namespace Aplicativo.Controllers
{
    public class RolesPermisoController : Controller
    {
        private readonly MedellinSalvajeContext _context;

        public RolesPermisoController(MedellinSalvajeContext context)
        {
            _context = context;
        }

        // GET: RolesPermiso
        public async Task<IActionResult> Index()
        {
            var medellinSalvajeContext = _context.RolesPermisos.Include(r => r.IdPermisoNavigation).Include(r => r.IdRolNavigation);
            return View(await medellinSalvajeContext.ToListAsync());
        }

        // GET: RolesPermiso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesPermiso = await _context.RolesPermisos
                .Include(r => r.IdPermisoNavigation)
                .Include(r => r.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdRolPermiso == id);
            if (rolesPermiso == null)
            {
                return NotFound();
            }

            return View(rolesPermiso);
        }

        // GET: RolesPermiso/Create
        public IActionResult Create()
        {
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso");
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return View();
        }

        // POST: RolesPermiso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRolPermiso,IdRol,IdPermiso")] RolesPermiso rolesPermiso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolesPermiso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", rolesPermiso.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", rolesPermiso.IdRol);
            return View(rolesPermiso);
        }

        // GET: RolesPermiso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesPermiso = await _context.RolesPermisos.FindAsync(id);
            if (rolesPermiso == null)
            {
                return NotFound();
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", rolesPermiso.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", rolesPermiso.IdRol);
            return View(rolesPermiso);
        }

        // POST: RolesPermiso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRolPermiso,IdRol,IdPermiso")] RolesPermiso rolesPermiso)
        {
            if (id != rolesPermiso.IdRolPermiso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesPermiso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesPermisoExists(rolesPermiso.IdRolPermiso))
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
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", rolesPermiso.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", rolesPermiso.IdRol);
            return View(rolesPermiso);
        }

        // GET: RolesPermiso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesPermiso = await _context.RolesPermisos
                .Include(r => r.IdPermisoNavigation)
                .Include(r => r.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdRolPermiso == id);
            if (rolesPermiso == null)
            {
                return NotFound();
            }

            return View(rolesPermiso);
        }

        // POST: RolesPermiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolesPermiso = await _context.RolesPermisos.FindAsync(id);
            if (rolesPermiso != null)
            {
                _context.RolesPermisos.Remove(rolesPermiso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesPermisoExists(int id)
        {
            return _context.RolesPermisos.Any(e => e.IdRolPermiso == id);
        }
    }
}
