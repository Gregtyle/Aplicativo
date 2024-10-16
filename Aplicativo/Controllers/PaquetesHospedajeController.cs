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
    public class PaquetesHospedajeController : Controller
    {
        private readonly MedellinSalvajeContext _context;

        public PaquetesHospedajeController(MedellinSalvajeContext context)
        {
            _context = context;
        }

        // GET: PaquetesHospedaje
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaquetesHospedajes.ToListAsync());
        }

        // GET: PaquetesHospedaje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHospedaje = await _context.PaquetesHospedajes
                .FirstOrDefaultAsync(m => m.IdPaquete == id);
            if (paquetesHospedaje == null)
            {
                return NotFound();
            }

            return View(paquetesHospedaje);
        }

        // GET: PaquetesHospedaje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaquetesHospedaje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaquete,Nombre,Descripcion,PrecioTotal,Duracion")] PaquetesHospedaje paquetesHospedaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paquetesHospedaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paquetesHospedaje);
        }

        // GET: PaquetesHospedaje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHospedaje = await _context.PaquetesHospedajes.FindAsync(id);
            if (paquetesHospedaje == null)
            {
                return NotFound();
            }
            return View(paquetesHospedaje);
        }

        // POST: PaquetesHospedaje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaquete,Nombre,Descripcion,PrecioTotal,Duracion")] PaquetesHospedaje paquetesHospedaje)
        {
            if (id != paquetesHospedaje.IdPaquete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquetesHospedaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaquetesHospedajeExists(paquetesHospedaje.IdPaquete))
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
            return View(paquetesHospedaje);
        }

        // GET: PaquetesHospedaje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHospedaje = await _context.PaquetesHospedajes
                .FirstOrDefaultAsync(m => m.IdPaquete == id);
            if (paquetesHospedaje == null)
            {
                return NotFound();
            }

            return View(paquetesHospedaje);
        }

        // POST: PaquetesHospedaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paquetesHospedaje = await _context.PaquetesHospedajes.FindAsync(id);
            if (paquetesHospedaje != null)
            {
                _context.PaquetesHospedajes.Remove(paquetesHospedaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaquetesHospedajeExists(int id)
        {
            return _context.PaquetesHospedajes.Any(e => e.IdPaquete == id);
        }
    }
}
