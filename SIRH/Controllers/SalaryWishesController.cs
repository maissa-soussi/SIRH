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
    public class SalaryWishesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public SalaryWishesController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/SalaryWishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryWish>>> GetSalaryWish()
        {
            return await _context.SalaryWish.ToListAsync();
        }

        // GET: api/SalaryWishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryWish>> GetSalaryWish(int id)
        {
            var salaryWish = await _context.SalaryWish.FindAsync(id);

            if (salaryWish == null)
            {
                return NotFound();
            }

            return salaryWish;
        }

        // PUT: api/SalaryWishes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryWish(int id, SalaryWish salaryWish)
        {
            if (id != salaryWish.Id)
            {
                return BadRequest();
            }

            _context.Entry(salaryWish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryWishExists(id))
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

        // POST: api/SalaryWishes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalaryWish>> PostSalaryWish(SalaryWish salaryWish)
        {
            _context.SalaryWish.Add(salaryWish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaryWish", new { id = salaryWish.Id }, salaryWish);
        }

        // DELETE: api/SalaryWishes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalaryWish>> DeleteSalaryWish(int id)
        {
            var salaryWish = await _context.SalaryWish.FindAsync(id);
            if (salaryWish == null)
            {
                return NotFound();
            }

            _context.SalaryWish.Remove(salaryWish);
            await _context.SaveChangesAsync();

            return salaryWish;
        }

        private bool SalaryWishExists(int id)
        {
            return _context.SalaryWish.Any(e => e.Id == id);
        }
    }
}
