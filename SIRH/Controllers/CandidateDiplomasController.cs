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
    public class CandidateDiplomasController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CandidateDiplomasController(SIRHContext context)
        {
            _context = context;
        }

        public async Task<List<Diploma>> GetAllByIdAsync(int idCandidate)
        {
            List<CandidateDiploma> listes = await _context.CandidateDiploma.ToListAsync();
            List<Diploma> dip=new List<Diploma>();
            foreach (CandidateDiploma element in listes)
                {
                if (element.CandidateId == idCandidate)
                    dip.Add(element.Diploma);

            }
            return dip;

        }
        // GET: api/CandidateDiplomas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDiploma>>> GetCandidateDiploma()
        {
            List<CandidateDiploma> listes = await _context.CandidateDiploma.ToListAsync();
            foreach (CandidateDiploma element in listes)
            {
                element.Diploma = await _context.Diploma.FindAsync(element.DiplomaId);
                element.EducationLevel = await _context.EducationLevel.FindAsync(element.EducationLevelId);
                element.Domain = await _context.Domain.FindAsync(element.DomainId);
                element.Candidate = await _context.Candidate.FindAsync(element.CandidateId);
                element.Candidate.User = await _context.User.FindAsync(element.Candidate.UserId);
                element.Candidate.Country = await _context.Country.FindAsync(element.Candidate.CountryId);
                element.Candidate.Other = await _context.Other.FindAsync(element.Candidate.OtherId);
                element.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(element.Candidate.Other.SalaryWishId);
                element.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(element.Candidate.Other.DrivingLicenceId);

            }
            return listes;
        }

        // GET: api/CandidateDiplomas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDiploma>> GetCandidateDiploma(int id)
        {
            var candidateDiploma = await _context.CandidateDiploma.FindAsync(id);


            if (candidateDiploma == null)
            {
                return NotFound();
            }
            candidateDiploma.Diploma = await _context.Diploma.FindAsync(candidateDiploma.DiplomaId);
            candidateDiploma.EducationLevel = await _context.EducationLevel.FindAsync(candidateDiploma.EducationLevelId);
            candidateDiploma.Domain = await _context.Domain.FindAsync(candidateDiploma.DomainId);
            candidateDiploma.Candidate = await _context.Candidate.FindAsync(candidateDiploma.CandidateId);
            candidateDiploma.Candidate.User = await _context.User.FindAsync(candidateDiploma.Candidate.UserId);
            candidateDiploma.Candidate.Country = await _context.Country.FindAsync(candidateDiploma.Candidate.CountryId);
            candidateDiploma.Candidate.Other = await _context.Other.FindAsync(candidateDiploma.Candidate.OtherId);
            candidateDiploma.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidateDiploma.Candidate.Other.SalaryWishId);
            candidateDiploma.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidateDiploma.Candidate.Other.DrivingLicenceId);

            return candidateDiploma;
        }

        // PUT: api/CandidateDiplomas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateDiploma(int id, CandidateDiploma candidateDiploma)
        {
            if (id != candidateDiploma.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidateDiploma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateDiplomaExists(id))
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

        // POST: api/CandidateDiplomas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CandidateDiploma>> PostCandidateDiploma(CandidateDiploma candidateDiploma)
        {
            candidateDiploma.Diploma = await _context.Diploma.FindAsync(candidateDiploma.DiplomaId);
            candidateDiploma.EducationLevel = await _context.EducationLevel.FindAsync(candidateDiploma.EducationLevelId);
            candidateDiploma.Domain = await _context.Domain.FindAsync(candidateDiploma.DomainId);
            candidateDiploma.Candidate = await _context.Candidate.FindAsync(candidateDiploma.CandidateId);
            candidateDiploma.Candidate.User = await _context.User.FindAsync(candidateDiploma.Candidate.UserId);
            candidateDiploma.Candidate.Country = await _context.Country.FindAsync(candidateDiploma.Candidate.CountryId);
            candidateDiploma.Candidate.Other = await _context.Other.FindAsync(candidateDiploma.Candidate.OtherId);
            candidateDiploma.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidateDiploma.Candidate.Other.SalaryWishId);
            candidateDiploma.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidateDiploma.Candidate.Other.DrivingLicenceId);

            _context.CandidateDiploma.Add(candidateDiploma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateDiploma", new { id = candidateDiploma.Id }, candidateDiploma);
        }

        // DELETE: api/CandidateDiplomas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateDiploma>> DeleteCandidateDiploma(int id)
        {
            var candidateDiploma = await _context.CandidateDiploma.FindAsync(id);
            if (candidateDiploma == null)
            {
                return NotFound();
            }

            _context.CandidateDiploma.Remove(candidateDiploma);
            await _context.SaveChangesAsync();

            return candidateDiploma;
        }

        private bool CandidateDiplomaExists(int id)
        {
            return _context.CandidateDiploma.Any(e => e.Id == id);
        }
    }
}