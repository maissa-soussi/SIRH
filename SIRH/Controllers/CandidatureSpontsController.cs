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
    public class CandidatureSpontsController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CandidatureSpontsController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/CandidatureSponts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidatureSpont>>> GetCandidatureSpont()
        {
            List<CandidatureSpont> candidatures = await _context.CandidatureSpont.ToListAsync();
            foreach (CandidatureSpont ca in candidatures)
            {
                ca.Candidate = await _context.Candidate.FindAsync(ca.CandidateId);
                ca.Status = await _context.Status.FindAsync(ca.StatusId);
                ca.Candidate.User = await _context.User.FindAsync(ca.Candidate.UserId);
                ca.Candidate.Country = await _context.Country.FindAsync(ca.Candidate.CountryId);
                ca.Candidate.SalaryWish = await _context.SalaryWish.FindAsync(ca.Candidate.SalaryWishId);
                ca.Candidate.DrivingLicence = await _context.DrivingLicence.FindAsync(ca.Candidate.DrivingLicenceId);
            }
            return candidatures;
           
        }

        // GET: api/CandidatureSponts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidatureSpont>> GetCandidatureSpont(int id)
        {
            var candidature = await _context.CandidatureSpont.FindAsync(id);
            candidature.Candidate = await _context.Candidate.FindAsync(candidature.CandidateId);
            candidature.Status = await _context.Status.FindAsync(candidature.StatusId);
            candidature.Candidate.User = await _context.User.FindAsync(candidature.Candidate.UserId);
            candidature.Candidate.Country = await _context.Country.FindAsync(candidature.Candidate.CountryId);
            candidature.Candidate.SalaryWish = await _context.SalaryWish.FindAsync(candidature.Candidate.SalaryWishId);
            candidature.Candidate.DrivingLicence = await _context.DrivingLicence.FindAsync(candidature.Candidate.DrivingLicenceId);
           

            if (candidature == null)
            {
                return NotFound();
            }

            return candidature;
        }

        // PUT: api/CandidatureSponts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidatureSpont(int id, CandidatureSpont candidatureSpont)
        {
            if (id != candidatureSpont.Id)
            {
                return BadRequest();
            }
            _context.Entry(candidatureSpont).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatureSpontExists(id))
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

        // POST: api/CandidatureSponts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CandidatureSpont>> PostCandidatureSpont(CandidatureSpont candidatureSpont)
        {           
            _context.CandidatureSpont.Add(candidatureSpont);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidatureSpont", new { id = candidatureSpont.Id }, candidatureSpont);
        }

        // DELETE: api/CandidatureSponts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidatureSpont>> DeleteCandidatureSpont(int id)
        {
            var candidatureSpont = await _context.CandidatureSpont.FindAsync(id);
            if (candidatureSpont == null)
            {
                return NotFound();
            }

            _context.CandidatureSpont.Remove(candidatureSpont);
            await _context.SaveChangesAsync();

            return candidatureSpont;
        }

        private bool CandidatureSpontExists(int id)
        {
            return _context.CandidatureSpont.Any(e => e.Id == id);
        }
    }
}
