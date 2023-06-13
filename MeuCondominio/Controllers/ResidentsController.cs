using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuCondominio.Data;
using MeuCondominio.Models;

namespace MeuCondominio.Controllers
{
    public class ResidentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResidentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Residents
        public async Task<IActionResult> Index()
        {
              return _context.Resident != null ? 
                          View(await _context.Resident.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Resident'  is null.");
        }

        // GET: Residents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resident == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // GET: Residents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Residents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmergencyNumber,IfoodCode,IsManager,Id,Name,Email,Cpf,Phone,BirthDate")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resident);
        }

        // GET: Residents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resident == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }
            return View(resident);
        }

        // POST: Residents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmergencyNumber,IfoodCode,IsManager,Id,Name,Email,Cpf,Phone,BirthDate")] Resident resident)
        {
            if (id != resident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidentExists(resident.Id))
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
            return View(resident);
        }

        // GET: Residents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resident == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resident == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Resident'  is null.");
            }
            var resident = await _context.Resident.FindAsync(id);
            if (resident != null)
            {
                _context.Resident.Remove(resident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidentExists(int id)
        {
          return (_context.Resident?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
