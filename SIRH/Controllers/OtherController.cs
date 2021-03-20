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
    public class OtherController : ControllerBase
    {
        private readonly SIRHContext _context;

        public OtherController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/Other
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Other>>> GetOther()
        {
            List<Other> others = await _context.Other.ToListAsync();
            foreach (Other jo in others)
            {
                jo.SalaryWish = await _context.SalaryWish.FindAsync(jo.SalaryWishId);
                jo.DrivingLicence = await _context.DrivingLicence.FindAsync(jo.DrivingLicenceId);
                
            }
            return others;
        }

        // GET: api/Other/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Other>> GetOther(int id)
        {
            var other = await _context.Other.FindAsync(id);
            other.SalaryWish = await _context.SalaryWish.FindAsync(other.SalaryWishId);
            other.DrivingLicence = await _context.DrivingLicence.FindAsync(other.DrivingLicenceId);
            if (other == null)
            {
                return NotFound();
            }

            return other;
        }

        // PUT: api/Other/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOther(int id, Other other)
        {
            if (id != other.Id)
            {
                return BadRequest();
            }

            _context.Entry(other).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherExists(id))
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

        // POST: api/Other
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Other>> PostOther(Other other)
        {
            other.SalaryWish = await _context.SalaryWish.FindAsync(other.SalaryWishId);
            other.DrivingLicence = await _context.DrivingLicence.FindAsync(other.DrivingLicenceId);
            _context.Other.Add(other);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOther", new { id = other.Id }, other);
        }

        // DELETE: api/Other/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Other>> DeleteOther(int id)
        {
            var other = await _context.Other.FindAsync(id);
            if (other == null)
            {
                return NotFound();
            }

            _context.Other.Remove(other);
            await _context.SaveChangesAsync();

            return other;
        }

        private bool OtherExists(int id)
        {
            return _context.Other.Any(e => e.Id == id);
        }
    }
}
