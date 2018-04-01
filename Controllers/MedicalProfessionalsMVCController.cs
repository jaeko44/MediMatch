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

        // GET: MedicalProfessionalsMVC
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalProfessional.ToListAsync());
        }

        // GET: MedicalProfessionalsMVC/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalProfessional = await _context.MedicalProfessional
                .SingleOrDefaultAsync(m => m.Id == id);
            if (medicalProfessional == null)
            {
                return NotFound();
            }

            return View(medicalProfessional);
        }

        // GET: MedicalProfessionalsMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalProfessionalsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstMidName,LastName,ServiceCategory,FacilityId,Notes,Email,PhoneNumber")] MedicalProfessional medicalProfessional)
        {
            if (ModelState.IsValid)
            {
                medicalProfessional.Id = Guid.NewGuid();
                _context.Add(medicalProfessional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalProfessional);
        }

        // GET: MedicalProfessionalsMVC/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalProfessional = await _context.MedicalProfessional.SingleOrDefaultAsync(m => m.Id == id);
            if (medicalProfessional == null)
            {
                return NotFound();
            }
            return View(medicalProfessional);
        }

        // POST: MedicalProfessionalsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstMidName,LastName,ServiceCategory,FacilityId,Notes,Email,PhoneNumber")] MedicalProfessional medicalProfessional)
        {
            if (id != medicalProfessional.Id)
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
                    if (!MedicalProfessionalExists(medicalProfessional.Id))
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

        // GET: MedicalProfessionalsMVC/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalProfessional = await _context.MedicalProfessional
                .SingleOrDefaultAsync(m => m.Id == id);
            if (medicalProfessional == null)
            {
                return NotFound();
            }

            return View(medicalProfessional);
        }

        // POST: MedicalProfessionalsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var medicalProfessional = await _context.MedicalProfessional.SingleOrDefaultAsync(m => m.Id == id);
            _context.MedicalProfessional.Remove(medicalProfessional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalProfessionalExists(Guid id)
        {
            return _context.MedicalProfessional.Any(e => e.Id == id);
        }
    }
}
