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
    public class ReservasController : Controller
    {
        private readonly MedellinSalvajeContext _context;

        public ReservasController(MedellinSalvajeContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var medellinSalvajeContext = _context.Reservas.Include(r => r.DocumentoClienteNavigation).Include(r => r.DocumentoUsuarioNavigation).Include(r => r.IdAbonoNavigation).Include(r => r.IdMetodoPagoNavigation).Include(r => r.NitNavigation);
            return View(await medellinSalvajeContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.DocumentoClienteNavigation)
                .Include(r => r.DocumentoUsuarioNavigation)
                .Include(r => r.IdAbonoNavigation)
                .Include(r => r.IdMetodoPagoNavigation)
                .Include(r => r.NitNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["DocumentoCliente"] = new SelectList(_context.Clientes, "Documento", "Documento");
            ViewData["DocumentoUsuario"] = new SelectList(_context.Usuarios, "Documento", "Documento");
            ViewData["IdAbono"] = new SelectList(_context.Abonos, "IdAbono", "IdAbono");
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago");
            ViewData["Nit"] = new SelectList(_context.Empresas, "Nit", "Nit");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,FechaReserva,FechaInicio,FechaFin,Subtotal,Iva,Total,DocumentoCliente,DocumentoUsuario,IdAbono,Nit,Estado,IdMetodoPago")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentoCliente"] = new SelectList(_context.Clientes, "Documento", "Documento", reserva.DocumentoCliente);
            ViewData["DocumentoUsuario"] = new SelectList(_context.Usuarios, "Documento", "Documento", reserva.DocumentoUsuario);
            ViewData["IdAbono"] = new SelectList(_context.Abonos, "IdAbono", "IdAbono", reserva.IdAbono);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", reserva.IdMetodoPago);
            ViewData["Nit"] = new SelectList(_context.Empresas, "Nit", "Nit", reserva.Nit);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["DocumentoCliente"] = new SelectList(_context.Clientes, "Documento", "Documento", reserva.DocumentoCliente);
            ViewData["DocumentoUsuario"] = new SelectList(_context.Usuarios, "Documento", "Documento", reserva.DocumentoUsuario);
            ViewData["IdAbono"] = new SelectList(_context.Abonos, "IdAbono", "IdAbono", reserva.IdAbono);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", reserva.IdMetodoPago);
            ViewData["Nit"] = new SelectList(_context.Empresas, "Nit", "Nit", reserva.Nit);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,FechaReserva,FechaInicio,FechaFin,Subtotal,Iva,Total,DocumentoCliente,DocumentoUsuario,IdAbono,Nit,Estado,IdMetodoPago")] Reserva reserva)
        {
            if (id != reserva.IdReserva)
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
                    if (!ReservaExists(reserva.IdReserva))
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
            ViewData["DocumentoCliente"] = new SelectList(_context.Clientes, "Documento", "Documento", reserva.DocumentoCliente);
            ViewData["DocumentoUsuario"] = new SelectList(_context.Usuarios, "Documento", "Documento", reserva.DocumentoUsuario);
            ViewData["IdAbono"] = new SelectList(_context.Abonos, "IdAbono", "IdAbono", reserva.IdAbono);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", reserva.IdMetodoPago);
            ViewData["Nit"] = new SelectList(_context.Empresas, "Nit", "Nit", reserva.Nit);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.DocumentoClienteNavigation)
                .Include(r => r.DocumentoUsuarioNavigation)
                .Include(r => r.IdAbonoNavigation)
                .Include(r => r.IdMetodoPagoNavigation)
                .Include(r => r.NitNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
