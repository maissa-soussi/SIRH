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
    public class CandidateExperiencesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CandidateExperiencesController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/CandidateExperiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateExperience>>> GetCandidateExperience()
        {
            List<CandidateExperience> candidateExperiences = await _context.CandidateExperience.ToListAsync();
            foreach (CandidateExperience ce in candidateExperiences)
            {
                ce.Experience = await _context.Experience.FindAsync(ce.ExperienceId);
                ce.Domain = await _context.Domain.FindAsync(ce.DomainId);
                ce.Candidate = await _context.Candidate.FindAsync(ce.CandidateId);
            }
            return candidateExperiences;
        }

        // GET: api/CandidateExperiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateExperience>> GetCandidateExperience(int id)
        {
            var candidateExperience = await _context.CandidateExperience.FindAsync(id);
            candidateExperience.Experience = await _context.Experience.FindAsync(candidateExperience.ExperienceId);
            candidateExperience.Domain = await _context.Domain.FindAsync(candidateExperience.DomainId);
            candidateExperience.Candidate = await _context.Candidate.FindAsync(candidateExperience.CandidateId);

            if (candidateExperience == null)
            {
                return NotFound();
            }

            return candidateExperience;
        }

        // PUT: api/CandidateExperiences/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateExperience(int id, CandidateExperience candidateExperience)
        {
            if (id != candidateExperience.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidateExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExperienceExists(id))
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

        // POST: api/CandidateExperiences
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CandidateExperience>> PostCandidateExperience(CandidateExperience candidateExperience)
        {
            candidateExperience.Experience = await _context.Experience.FindAsync(candidateExperience.ExperienceId);
            candidateExperience.Domain = await _context.Domain.FindAsync(candidateExperience.DomainId);
            candidateExperience.Candidate = await _context.Candidate.FindAsync(candidateExperience.CandidateId);
            _context.CandidateExperience.Add(candidateExperience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateExperience", new { id = candidateExperience.Id }, candidateExperience);
        }

        // DELETE: api/CandidateExperiences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateExperience>> DeleteCandidateExperience(int id)
        {
            var candidateExperience = await _context.CandidateExperience.FindAsync(id);
            if (candidateExperience == null)
            {
                return NotFound();
            }

            _context.CandidateExperience.Remove(candidateExperience);
            await _context.SaveChangesAsync();

            return candidateExperience;
        }

        private bool CandidateExperienceExists(int id)
        {
            return _context.CandidateExperience.Any(e => e.Id == id);
        }
    }
}
