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
    public class ContratTypesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public ContratTypesController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/ContratTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratType>>> GetContratType()
        {
            return await _context.ContratType.ToListAsync();
        }

        // GET: api/ContratTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContratType>> GetContratType(int id)
        {
            var contratType = await _context.ContratType.FindAsync(id);

            if (contratType == null)
            {
                return NotFound();
            }

            return contratType;
        }

        // PUT: api/ContratTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContratType(int id, ContratType contratType)
        {
            if (id != contratType.Id)
            {
                return BadRequest();
            }

            _context.Entry(contratType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratTypeExists(id))
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

        // POST: api/ContratTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContratType>> PostContratType(ContratType contratType)
        {
            _context.ContratType.Add(contratType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContratType", new { id = contratType.Id }, contratType);
        }

        // DELETE: api/ContratTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContratType>> DeleteContratType(int id)
        {
            var contratType = await _context.ContratType.FindAsync(id);
            if (contratType == null)
            {
                return NotFound();
            }

            _context.ContratType.Remove(contratType);
            await _context.SaveChangesAsync();

            return contratType;
        }

        private bool ContratTypeExists(int id)
        {
            return _context.ContratType.Any(e => e.Id == id);
        }
    }
}
