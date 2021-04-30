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
    public class EducationLevelsController : ControllerBase
    {
        private readonly SIRHContext _context;

        public EducationLevelsController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/EducationLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationLevel>>> GetEducationLevel()
        {
            return await _context.EducationLevel.ToListAsync();
        }

        // GET: api/EducationLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationLevel>> GetEducationLevel(int id)
        {
            var educationLevel = await _context.EducationLevel.FindAsync(id);

            if (educationLevel == null)
            {
                return NotFound();
            }

            return educationLevel;
        }

        // PUT: api/EducationLevels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationLevel(int id, EducationLevel educationLevel)
        {
            if (id != educationLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationLevelExists(id))
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

        // POST: api/EducationLevels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EducationLevel>> PostEducationLevel(EducationLevel educationLevel)
        {
            _context.EducationLevel.Add(educationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationLevel", new { id = educationLevel.Id }, educationLevel);
        }

        // DELETE: api/EducationLevels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EducationLevel>> DeleteEducationLevel(int id)
        {
            var educationLevel = await _context.EducationLevel.FindAsync(id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            _context.EducationLevel.Remove(educationLevel);
            await _context.SaveChangesAsync();

            return educationLevel;
        }

        private bool EducationLevelExists(int id)
        {
            return _context.EducationLevel.Any(e => e.Id == id);
        }
    }
}
