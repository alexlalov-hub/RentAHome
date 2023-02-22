using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentAHome.Data;
using RentAHome.Models;

namespace RentAHome.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Advertisement
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Advertisements.Include(a => a.Creator).Include(a => a.Property);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Advertisement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Advertisements == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .Include(a => a.Creator)
                .Include(a => a.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // GET: Advertisement/Create
        public IActionResult Create()
        {
            ViewData["CreatorId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Desciption");
            return View();
        }

        // POST: Advertisement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PropertyId,CreatorId,CreationDate,EndDate")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", advertisement.CreatorId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Desciption", advertisement.PropertyId);
            return View(advertisement);
        }

        // GET: Advertisement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Advertisements == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", advertisement.CreatorId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Desciption", advertisement.PropertyId);
            return View(advertisement);
        }

        // POST: Advertisement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PropertyId,CreatorId,CreationDate,EndDate")] Advertisement advertisement)
        {
            if (id != advertisement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertisement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisementExists(advertisement.Id))
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
            ViewData["CreatorId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", advertisement.CreatorId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Desciption", advertisement.PropertyId);
            return View(advertisement);
        }

        // GET: Advertisement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Advertisements == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .Include(a => a.Creator)
                .Include(a => a.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Advertisements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Advertisements'  is null.");
            }
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement != null)
            {
                _context.Advertisements.Remove(advertisement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(int id)
        {
          return (_context.Advertisements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
