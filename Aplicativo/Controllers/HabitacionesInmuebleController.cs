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
    public class HabitacionesInmuebleController : Controller
    {
        private readonly MedellinSalvajeContext _context;

        public HabitacionesInmuebleController(MedellinSalvajeContext context)
        {
            _context = context;
        }

        // GET: HabitacionesInmueble
        public async Task<IActionResult> Index()
        {
            var medellinSalvajeContext = _context.HabitacionesInmuebles.Include(h => h.IdHabitacionNavigation).Include(h => h.IdInmuebleNavigation);
            return View(await medellinSalvajeContext.ToListAsync());
        }

        // GET: HabitacionesInmueble/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacionesInmueble = await _context.HabitacionesInmuebles
                .Include(h => h.IdHabitacionNavigation)
                .Include(h => h.IdInmuebleNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habitacionesInmueble == null)
            {
                return NotFound();
            }

            return View(habitacionesInmueble);
        }

        // GET: HabitacionesInmueble/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion");
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble");
            return View();
        }

        // POST: HabitacionesInmueble/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdHabitacion,IdInmueble")] HabitacionesInmueble habitacionesInmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacionesInmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", habitacionesInmueble.IdHabitacion);
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", habitacionesInmueble.IdInmueble);
            return View(habitacionesInmueble);
        }

        // GET: HabitacionesInmueble/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacionesInmueble = await _context.HabitacionesInmuebles.FindAsync(id);
            if (habitacionesInmueble == null)
            {
                return NotFound();
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", habitacionesInmueble.IdHabitacion);
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", habitacionesInmueble.IdInmueble);
            return View(habitacionesInmueble);
        }

        // POST: HabitacionesInmueble/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdHabitacion,IdInmueble")] HabitacionesInmueble habitacionesInmueble)
        {
            if (id != habitacionesInmueble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacionesInmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionesInmuebleExists(habitacionesInmueble.Id))
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
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", habitacionesInmueble.IdHabitacion);
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", habitacionesInmueble.IdInmueble);
            return View(habitacionesInmueble);
        }

        // GET: HabitacionesInmueble/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacionesInmueble = await _context.HabitacionesInmuebles
                .Include(h => h.IdHabitacionNavigation)
                .Include(h => h.IdInmuebleNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habitacionesInmueble == null)
            {
                return NotFound();
            }

            return View(habitacionesInmueble);
        }

        // POST: HabitacionesInmueble/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacionesInmueble = await _context.HabitacionesInmuebles.FindAsync(id);
            if (habitacionesInmueble != null)
            {
                _context.HabitacionesInmuebles.Remove(habitacionesInmueble);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionesInmuebleExists(int id)
        {
            return _context.HabitacionesInmuebles.Any(e => e.Id == id);
        }
    }
}
