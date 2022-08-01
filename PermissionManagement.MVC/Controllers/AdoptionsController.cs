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
    public class AdoptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adoptions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Adoption.ToListAsync());
        }

        // GET: Adoptions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Adoption == null)
            {
                return NotFound();
            }

            var adoption = await _context.Adoption
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoption == null)
            {
                return NotFound();
            }

            return View(adoption);
        }

        // GET: Adoptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adoptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Status,Name,AdoptingUser")] Adoption adoption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adoption);
        }

        // GET: Adoptions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Adoption == null)
            {
                return NotFound();
            }

            var adoption = await _context.Adoption.FindAsync(id);
            if (adoption == null)
            {
                return NotFound();
            }
            return View(adoption);
        }

        // POST: Adoptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Status,Name,AdoptingUser")] Adoption adoption)
        {
            if (id != adoption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionExists(adoption.Id))
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
            return View(adoption);
        }

        // GET: Adoptions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Adoption == null)
            {
                return NotFound();
            }

            var adoption = await _context.Adoption
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoption == null)
            {
                return NotFound();
            }

            return View(adoption);
        }

        // POST: Adoptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Adoption == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Adoption'  is null.");
            }
            var adoption = await _context.Adoption.FindAsync(id);
            if (adoption != null)
            {
                _context.Adoption.Remove(adoption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionExists(string id)
        {
          return _context.Adoption.Any(e => e.Id == id);
        }
    }
}
