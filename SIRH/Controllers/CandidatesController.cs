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
    public class CandidatesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CandidatesController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/Candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidate()
        {
            

            List<Candidate> candidates = await _context.Candidate.ToListAsync();
            foreach (Candidate ca in candidates)
            {
                ca.User = await _context.User.FindAsync(ca.UserId);
                ca.Country = await _context.Country.FindAsync(ca.CountryId);
                ca.Other = await _context.Other.FindAsync(ca.OtherId);
                ca.Other.SalaryWish = await _context.SalaryWish.FindAsync(ca.Other.SalaryWishId);
                ca.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(ca.Other.DrivingLicenceId);

            }
            return candidates;
        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            var candidate = await _context.Candidate.FindAsync(id);
            candidate.User = await _context.User.FindAsync(candidate.UserId);
            candidate.Country = await _context.Country.FindAsync(candidate.CountryId);
            candidate.Other = await _context.Other.FindAsync(candidate.OtherId);
            candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidate.Other.SalaryWishId);
            candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidate.Other.DrivingLicenceId);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // PUT: api/Candidates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/Candidates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            candidate.User = await _context.User.FindAsync(candidate.UserId);
            candidate.Country = await _context.Country.FindAsync(candidate.CountryId);
            candidate.Other = await _context.Other.FindAsync(candidate.OtherId);
            candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidate.Other.SalaryWishId);
            candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidate.Other.DrivingLicenceId);
            _context.Candidate.Add(candidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidate.Remove(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.Id == id);
        }
    }
}
