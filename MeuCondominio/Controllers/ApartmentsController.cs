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
using Microsoft.AspNetCore.Authorization;

namespace MeuCondominio.Controllers
{
    [Authorize]
    public class ApartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Apartment.Include(a => a.Building);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Apartment == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment
                .Include(a => a.Building)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            var viewModel = new ApartmentFormViewModel();
            viewModel.Buildings = _context.Building.ToList();
            return View(viewModel);
        }

        // POST: Apartments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Apartment apartment)
        {
            _context.Add(apartment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Apartment == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }

            ApartmentFormViewModel apartmentFormViewModel = new ApartmentFormViewModel();
            apartmentFormViewModel.Apartment = apartment;
            apartmentFormViewModel.Buildings = _context.Building.ToList();

            return View(apartmentFormViewModel);
        }

        // POST: Apartments/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Apartment apartment)
        {
            if (!_context.Apartment.Any(s => s.Id == apartment.Id))
            {
                return NotFound();
            }

            _context.Update(apartment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Apartment == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment
                .Include(a => a.Building)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Apartment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Apartment'  is null.");
            }
            var apartment = await _context.Apartment.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartment.Remove(apartment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
          return (_context.Apartment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
