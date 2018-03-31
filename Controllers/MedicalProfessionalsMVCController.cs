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
    public class MedicalProfessionalsMVCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalProfessionalsMVCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalProfessionals1
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalProfessional.ToListAsync());
        }

        // GET: MedicalProfessionals1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalProfessional = await _context.MedicalProfessional
                .SingleOrDefaultAsync(m => m.MedicalId == id);
            if (medicalProfessional == null)
            {
                return NotFound();
            }

            return View(medicalProfessional);
        }

        // GET: MedicalProfessionals1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalProfessionals1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalId,FacilityName,LastName,FirstMidName,Notes,Website,Email,PhoneNumber")] MedicalProfessional medicalProfessional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalProfessional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalProfessional);
        }

        // GET: MedicalProfessionals1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalProfessional = await _context.MedicalProfessional.SingleOrDefaultAsync(m => m.MedicalId == id);
            if (medicalProfessional == null)
            {
                return NotFound();
            }
            return View(medicalProfessional);
        }

        // POST: MedicalProfessionals1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalId,FacilityName,LastName,FirstMidName,Notes,Website,Email,PhoneNumber")] MedicalProfessional medicalProfessional)
        {
            if (id != medicalProfessional.MedicalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalProfessional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalProfessionalExists(medicalProfessional.MedicalId))
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
            return View(medicalProfessional);
        }

        // GET: MedicalProfessionals1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalProfessional = await _context.MedicalProfessional
                .SingleOrDefaultAsync(m => m.MedicalId == id);
            if (medicalProfessional == null)
            {
                return NotFound();
            }

            return View(medicalProfessional);
        }

        // POST: MedicalProfessionals1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalProfessional = await _context.MedicalProfessional.SingleOrDefaultAsync(m => m.MedicalId == id);
            _context.MedicalProfessional.Remove(medicalProfessional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalProfessionalExists(int id)
        {
            return _context.MedicalProfessional.Any(e => e.MedicalId == id);
        }
    }
}
