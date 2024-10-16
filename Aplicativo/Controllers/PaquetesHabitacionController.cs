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
    public class PaquetesHabitacionController : Controller
    {
        private readonly MedellinSalvajeContext _context;

        public PaquetesHabitacionController(MedellinSalvajeContext context)
        {
            _context = context;
        }

        // GET: PaquetesHabitacion
        public async Task<IActionResult> Index()
        {
            var medellinSalvajeContext = _context.PaquetesHabitaciones.Include(p => p.IdHabitacionNavigation).Include(p => p.IdPaqueteNavigation);
            return View(await medellinSalvajeContext.ToListAsync());
        }

        // GET: PaquetesHabitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHabitacione = await _context.PaquetesHabitaciones
                .Include(p => p.IdHabitacionNavigation)
                .Include(p => p.IdPaqueteNavigation)
                .FirstOrDefaultAsync(m => m.IdPaqueteHabitacion == id);
            if (paquetesHabitacione == null)
            {
                return NotFound();
            }

            return View(paquetesHabitacione);
        }

        // GET: PaquetesHabitacion/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion");
            ViewData["IdPaquete"] = new SelectList(_context.PaquetesHospedajes, "IdPaquete", "IdPaquete");
            return View();
        }

        // POST: PaquetesHabitacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaqueteHabitacion,IdPaquete,IdHabitacion")] PaquetesHabitacione paquetesHabitacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paquetesHabitacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", paquetesHabitacione.IdHabitacion);
            ViewData["IdPaquete"] = new SelectList(_context.PaquetesHospedajes, "IdPaquete", "IdPaquete", paquetesHabitacione.IdPaquete);
            return View(paquetesHabitacione);
        }

        // GET: PaquetesHabitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHabitacione = await _context.PaquetesHabitaciones.FindAsync(id);
            if (paquetesHabitacione == null)
            {
                return NotFound();
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", paquetesHabitacione.IdHabitacion);
            ViewData["IdPaquete"] = new SelectList(_context.PaquetesHospedajes, "IdPaquete", "IdPaquete", paquetesHabitacione.IdPaquete);
            return View(paquetesHabitacione);
        }

        // POST: PaquetesHabitacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaqueteHabitacion,IdPaquete,IdHabitacion")] PaquetesHabitacione paquetesHabitacione)
        {
            if (id != paquetesHabitacione.IdPaqueteHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquetesHabitacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaquetesHabitacioneExists(paquetesHabitacione.IdPaqueteHabitacion))
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
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", paquetesHabitacione.IdHabitacion);
            ViewData["IdPaquete"] = new SelectList(_context.PaquetesHospedajes, "IdPaquete", "IdPaquete", paquetesHabitacione.IdPaquete);
            return View(paquetesHabitacione);
        }

        // GET: PaquetesHabitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHabitacione = await _context.PaquetesHabitaciones
                .Include(p => p.IdHabitacionNavigation)
                .Include(p => p.IdPaqueteNavigation)
                .FirstOrDefaultAsync(m => m.IdPaqueteHabitacion == id);
            if (paquetesHabitacione == null)
            {
                return NotFound();
            }

            return View(paquetesHabitacione);
        }

        // POST: PaquetesHabitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paquetesHabitacione = await _context.PaquetesHabitaciones.FindAsync(id);
            if (paquetesHabitacione != null)
            {
                _context.PaquetesHabitaciones.Remove(paquetesHabitacione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaquetesHabitacioneExists(int id)
        {
            return _context.PaquetesHabitaciones.Any(e => e.IdPaqueteHabitacion == id);
        }
    }
}
