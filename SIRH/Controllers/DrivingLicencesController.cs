using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIRH.Data;
using SIRH.Models;

namespace SIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingLicencesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public DrivingLicencesController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/DrivingLicences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrivingLicence>>> GetDrivingLicence()
        {
            return await _context.DrivingLicence.ToListAsync();
        }

        // GET: api/DrivingLicences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrivingLicence>> GetDrivingLicence(int id)
        {
            var drivingLicence = await _context.DrivingLicence.FindAsync(id);

            if (drivingLicence == null)
            {
                return NotFound();
            }

            return drivingLicence;
        }

        // PUT: api/DrivingLicences/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrivingLicence(int id, DrivingLicence drivingLicence)
        {
            if (id != drivingLicence.Id)
            {
                return BadRequest();
            }

            _context.Entry(drivingLicence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrivingLicenceExists(id))
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

        // POST: api/DrivingLicences
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DrivingLicence>> PostDrivingLicence(DrivingLicence drivingLicence)
        {
            _context.DrivingLicence.Add(drivingLicence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrivingLicence", new { id = drivingLicence.Id }, drivingLicence);
        }

        // DELETE: api/DrivingLicences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DrivingLicence>> DeleteDrivingLicence(int id)
        {
            var drivingLicence = await _context.DrivingLicence.FindAsync(id);
            if (drivingLicence == null)
            {
                return NotFound();
            }

            _context.DrivingLicence.Remove(drivingLicence);
            await _context.SaveChangesAsync();

            return drivingLicence;
        }

        private bool DrivingLicenceExists(int id)
        {
            return _context.DrivingLicence.Any(e => e.Id == id);
        }
    }
}
