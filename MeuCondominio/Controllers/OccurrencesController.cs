using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuCondominio.Data;
using MeuCondominio.Models;
using MeuCondominio.Models.ViewModels;
using MeuCondominio.Models.Enums;

namespace MeuCondominio.Controllers
{
    public class OccurrencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OccurrencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Occurrences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Occurrence.Include(r => r.Resident);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Occurrences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Occurrence == null)
            {
                return NotFound();
            }

            var occurrence = await _context.Occurrence
                .Include(r => r.Resident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (occurrence == null)
            {
                return NotFound();
            }

            return View(occurrence);
        }

        // GET: Occurrences/Create
        public IActionResult Create()
        {
            var viewModel = new OccurrenceFormViewModel();
            viewModel.Residents = _context.Resident.ToList();

            return View(viewModel);
        }

        // POST: Occurrences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Occurrence occurrence)
        {
            _context.Add(occurrence);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Occurrences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Occurrence == null)
            {
                return NotFound();
            }

            var occurrence = await _context.Occurrence.FindAsync(id);
            if (occurrence == null)
            {
                return NotFound();
            }

            OccurrenceFormViewModel occurrenceFormViewModel = new OccurrenceFormViewModel();
            occurrenceFormViewModel.Occurrence = occurrence;
            occurrenceFormViewModel.Residents = _context.Resident.ToList();

            return View(occurrenceFormViewModel);
        }

        // POST: Occurrences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Occurrence occurrence)
        {
            if (id != occurrence.Id)
            {
                return NotFound();
            }

            _context.Update(occurrence);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Occurrences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Occurrence == null)
            {
                return NotFound();
            }

            var occurrence = await _context.Occurrence
                .Include(r => r.Resident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (occurrence == null)
            {
                return NotFound();
            }

            return View(occurrence);
        }

        // POST: Occurrences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Occurrence == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Occurrence'  is null.");
            }
            var occurrence = await _context.Occurrence.FindAsync(id);
            if (occurrence != null)
            {
                _context.Occurrence.Remove(occurrence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OccurrenceExists(int id)
        {
          return (_context.Occurrence?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
