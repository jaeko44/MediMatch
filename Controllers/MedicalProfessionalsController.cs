using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediMatchRMIT.Data;
using MediMatchRMIT.Models;

namespace MediMatchRMIT.Controllers
{
    [Produces("application/json")]
    [Route("api/MedicalProfessionals")]
    public class MedicalProfessionalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalProfessionalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalProfessionals
        [HttpGet]
        public IEnumerable<MedicalProfessional> GetMedicalProfessional()
        {
            return _context.MedicalProfessional;
        }

        // GET: api/MedicalProfessionals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalProfessional([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicalProfessional = await _context.MedicalProfessional.SingleOrDefaultAsync(m => m.Id == id);

            if (medicalProfessional == null)
            {
                return NotFound();
            }

            return Ok(medicalProfessional);
        }

        // PUT: api/MedicalProfessionals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalProfessional([FromRoute] Guid id, [FromBody] MedicalProfessional medicalProfessional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicalProfessional.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalProfessional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalProfessionalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MedicalProfessionals
        [HttpPost]
        public async Task<IActionResult> PostMedicalProfessional([FromBody] MedicalProfessional medicalProfessional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MedicalProfessional.Add(medicalProfessional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalProfessional", new { id = medicalProfessional.Id }, medicalProfessional);
        }

        // DELETE: api/MedicalProfessionals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalProfessional([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicalProfessional = await _context.MedicalProfessional.SingleOrDefaultAsync(m => m.Id == id);
            if (medicalProfessional == null)
            {
                return NotFound();
            }

            _context.MedicalProfessional.Remove(medicalProfessional);
            await _context.SaveChangesAsync();

            return Ok(medicalProfessional);
        }

        private bool MedicalProfessionalExists(Guid id)
        {
            return _context.MedicalProfessional.Any(e => e.Id == id);
        }
    }
}