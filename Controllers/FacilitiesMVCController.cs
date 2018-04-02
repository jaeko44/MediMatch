using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediMatchRMIT.Data;
using MediMatchRMIT.Models;

namespace MediMatchRMIT.Controllers
{
    public class FacilitiesMVCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacilitiesMVCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacilitiesMVC
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facility.ToListAsync());
        }

        // GET: FacilitiesMVC/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facility
                .SingleOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // GET: FacilitiesMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacilitiesMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FacilityId,FacilityName,Website,PhoneNo,Email")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                facility.Id = Guid.NewGuid();
                _context.Add(facility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facility);
        }

        // GET: FacilitiesMVC/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facility.SingleOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }
            return View(facility);
        }

        // POST: FacilitiesMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FacilityId,FacilityName,Website,PhoneNo,Email")] Facility facility)
        {
            if (id != facility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityExists(facility.Id))
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
            return View(facility);
        }

        // GET: FacilitiesMVC/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facility
                .SingleOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // POST: FacilitiesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var facility = await _context.Facility.SingleOrDefaultAsync(m => m.Id == id);
            _context.Facility.Remove(facility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(Guid id)
        {
            return _context.Facility.Any(e => e.Id == id);
        }
    }
}
