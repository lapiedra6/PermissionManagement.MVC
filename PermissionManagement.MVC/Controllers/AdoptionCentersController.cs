using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PermissionManagement.MVC.Data;
using PermissionManagement.MVC.Models;

namespace PermissionManagement.MVC.Controllers
{
    public class AdoptionCentersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionCentersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdoptionCenters
        public async Task<IActionResult> Index()
        {
              return View(await _context.AdoptionCenter.ToListAsync());
        }

        // GET: AdoptionCenters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AdoptionCenter == null)
            {
                return NotFound();
            }

            var adoptionCenter = await _context.AdoptionCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionCenter == null)
            {
                return NotFound();
            }

            return View(adoptionCenter);
        }

        // GET: AdoptionCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdoptionCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AdoptionCenter adoptionCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptionCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adoptionCenter);
        }

        // GET: AdoptionCenters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AdoptionCenter == null)
            {
                return NotFound();
            }

            var adoptionCenter = await _context.AdoptionCenter.FindAsync(id);
            if (adoptionCenter == null)
            {
                return NotFound();
            }
            return View(adoptionCenter);
        }

        // POST: AdoptionCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] AdoptionCenter adoptionCenter)
        {
            if (id != adoptionCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionCenterExists(adoptionCenter.Id))
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
            return View(adoptionCenter);
        }

        // GET: AdoptionCenters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AdoptionCenter == null)
            {
                return NotFound();
            }

            var adoptionCenter = await _context.AdoptionCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionCenter == null)
            {
                return NotFound();
            }

            return View(adoptionCenter);
        }

        // POST: AdoptionCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AdoptionCenter == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AdoptionCenter'  is null.");
            }
            var adoptionCenter = await _context.AdoptionCenter.FindAsync(id);
            if (adoptionCenter != null)
            {
                _context.AdoptionCenter.Remove(adoptionCenter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionCenterExists(string id)
        {
          return _context.AdoptionCenter.Any(e => e.Id == id);
        }

        public List<AdoptionCenter> GetCenters()
        {
            Task<List<AdoptionCenter>> centers = _context.AdoptionCenter.ToListAsync();

            return centers.Result;
        }
        public AdoptionCenter GetRecord(string id)
        {
            var adoptionCenter = _context.AdoptionCenter.FirstOrDefaultAsync(m => m.Id == id);

            return adoptionCenter.Result;
        }
    }
}
