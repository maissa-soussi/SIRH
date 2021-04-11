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
    public class CandidaturesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CandidaturesController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/Candidatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidature>>> GetCandidature()
        {
            List<Candidature> candidatures = await _context.Candidature.ToListAsync();
            foreach (Candidature ca in candidatures)
            {
                ca.Candidate = await _context.Candidate.FindAsync(ca.CandidateId);
                ca.Candidate.User = await _context.User.FindAsync(ca.Candidate.UserId);
                ca.Candidate.Country = await _context.Country.FindAsync(ca.Candidate.CountryId);
                ca.Candidate.Other = await _context.Other.FindAsync(ca.Candidate.OtherId);
                ca.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(ca.Candidate.Other.SalaryWishId);
                ca.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(ca.Candidate.Other.DrivingLicenceId);
                ca.JobOffer = await _context.JobOffer.FindAsync(ca.JobOfferId);
                ca.JobOffer.Country = await _context.Country.FindAsync(ca.JobOffer.CountryId);
                ca.JobOffer.Diploma = await _context.Diploma.FindAsync(ca.JobOffer.DiplomaId);
                ca.JobOffer.Experience = await _context.Experience.FindAsync(ca.JobOffer.ExperienceId);
                ca.JobOffer.ContratType = await _context.ContratType.FindAsync(ca.JobOffer.ContratTypeId);
                ca.JobOffer.Currency = await _context.Currency.FindAsync(ca.JobOffer.CurrencyId);

            }
            return candidatures;
        }

        // GET: api/Candidatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidature>> GetCandidature(int id)
        {
            var candidature = await _context.Candidature.FindAsync(id);
            candidature.Candidate = await _context.Candidate.FindAsync(candidature.CandidateId);
            candidature.Candidate.User = await _context.User.FindAsync(candidature.Candidate.UserId);
            candidature.Candidate.Country = await _context.Country.FindAsync(candidature.Candidate.CountryId);
            candidature.Candidate.Other = await _context.Other.FindAsync(candidature.Candidate.OtherId);
            candidature.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidature.Candidate.Other.SalaryWishId);
            candidature.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidature.Candidate.Other.DrivingLicenceId);
            candidature.JobOffer = await _context.JobOffer.FindAsync(candidature.JobOfferId);
            candidature.JobOffer.Country = await _context.Country.FindAsync(candidature.JobOffer.CountryId);
            candidature.JobOffer.Diploma = await _context.Diploma.FindAsync(candidature.JobOffer.DiplomaId);
            candidature.JobOffer.Experience = await _context.Experience.FindAsync(candidature.JobOffer.ExperienceId);
            candidature.JobOffer.ContratType = await _context.ContratType.FindAsync(candidature.JobOffer.ContratTypeId);
            candidature.JobOffer.Currency = await _context.Currency.FindAsync(candidature.JobOffer.CurrencyId);

            if (candidature == null)
            {
                return NotFound();
            }

            return candidature;
        }

        // PUT: api/Candidatures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidature(int id, Candidature candidature)
        {
            if (id != candidature.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatureExists(id))
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

        // POST: api/Candidatures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Candidature>> PostCandidature(Candidature candidature)
        {
            candidature.Candidate = await _context.Candidate.FindAsync(candidature.CandidateId);
            candidature.Candidate.User = await _context.User.FindAsync(candidature.Candidate.UserId);
            candidature.Candidate.Country = await _context.Country.FindAsync(candidature.Candidate.CountryId);
            candidature.Candidate.Other = await _context.Other.FindAsync(candidature.Candidate.OtherId);
            candidature.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidature.Candidate.Other.SalaryWishId);
            candidature.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidature.Candidate.Other.DrivingLicenceId);
            candidature.JobOffer = await _context.JobOffer.FindAsync(candidature.JobOfferId);
            candidature.JobOffer.Country = await _context.Country.FindAsync(candidature.JobOffer.CountryId);
            candidature.JobOffer.Diploma = await _context.Diploma.FindAsync(candidature.JobOffer.DiplomaId);
            candidature.JobOffer.Experience = await _context.Experience.FindAsync(candidature.JobOffer.ExperienceId);
            candidature.JobOffer.ContratType = await _context.ContratType.FindAsync(candidature.JobOffer.ContratTypeId);
            candidature.JobOffer.Currency = await _context.Currency.FindAsync(candidature.JobOffer.CurrencyId);
            _context.Candidature.Add(candidature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidature", new { id = candidature.Id }, candidature);
        }

        // DELETE: api/Candidatures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidature>> DeleteCandidature(int id)
        {
            var candidature = await _context.Candidature.FindAsync(id);
            if (candidature == null)
            {
                return NotFound();
            }

            _context.Candidature.Remove(candidature);
            await _context.SaveChangesAsync();

            return candidature;
        }

        private bool CandidatureExists(int id)
        {
            return _context.Candidature.Any(e => e.Id == id);
        }
    }
}
