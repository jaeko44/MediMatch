using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediMatchRMIT.Data;
using MediMatchRMIT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MediMatchRMIT.Controllers
{
    [Produces("application/json")]
    [Route("api/Facilities")]
    public class FacilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets All Facilities
        /// GET: api/Facilities
        /// </summary>
        [HttpGet]
        public IEnumerable<Facility> GetFacility()
        {
            return _context.Facility;
        }

        /// <summary>
        /// Gets a Facility by ID
        /// GET: api/Facilities/5
        /// </summary>
        /// <param name="id">The ID of the facility to retrieve.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacility([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facility = await _context.Facility.Include(m => m.Location.Coordinates).SingleOrDefaultAsync(m => m.Id == id);
            //facility.Location = await _context.Address.SingleOrDefaultAsync(m => m.Id == facility.LocationId);
            if (facility == null)
            {
                return NotFound();
            }

            return Ok(facility);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /// <summary>
        /// Update a Facility by ID
        /// PUT: api/Facilities/5
        /// </summary>
        /// <param name="id">The ID of the facility to update.</param>
        /// <param name="facility">The new facility data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacility([FromRoute] Guid id, [FromBody] Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facility.Id)
            {
                return BadRequest();
            }

            _context.Entry(facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(id))
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /// <summary>
        /// Add a new Facility
        /// POST: api/Facilities
        /// </summary>
        /// <param name="facility">The new facility data in [body].</param>
        [HttpPost]
        public async Task<IActionResult> PostFacility([FromBody] Facility facility)
        {
            //facility.Id = Guid.NewGuid();
            //facility.Location.Id = Guid.NewGuid();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Facility.Add(facility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /// <summary>
        /// Delete a Facility by ID
        /// DELETE: api/Facilities/5
        /// </summary>
        /// <param name="id">The ID of the facility to update.</param>
        /// <param name="facility">The new facility data.</param>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facility = await _context.Facility.SingleOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }

            _context.Facility.Remove(facility);
            await _context.SaveChangesAsync();

            return Ok(facility);
        }

        private bool FacilityExists(Guid id)
        {
            return _context.Facility.Any(e => e.Id == id);
        }
    }
}