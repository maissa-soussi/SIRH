﻿using System;
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
    public class CandidateLanguagesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CandidateLanguagesController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/CandidateLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateLanguage>>> GetCandidateLanguage()
        {
            

            List<CandidateLanguage> candidateLanguages = await _context.CandidateLanguage.ToListAsync();
            foreach (CandidateLanguage jo in candidateLanguages)
            {
                jo.Candidate = await _context.Candidate.FindAsync(jo.CandidateId);
                jo.Candidate.User = await _context.User.FindAsync(jo.Candidate.UserId);
                jo.Candidate.Country = await _context.Country.FindAsync(jo.Candidate.CountryId);
                jo.Candidate.Other = await _context.Other.FindAsync(jo.Candidate.OtherId);
                jo.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(jo.Candidate.Other.SalaryWishId);
                jo.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(jo.Candidate.Other.DrivingLicenceId);
                jo.Language = await _context.Language.FindAsync(jo.LanguageId);
                jo.LanguageLevel = await _context.LanguageLevel.FindAsync(jo.LanguageLevelId);

            }
            return candidateLanguages;
        }

        // GET: api/CandidateLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateLanguage>> GetCandidateLanguage(int id)
        {
            var candidateLanguage = await _context.CandidateLanguage.FindAsync(id);
            candidateLanguage.Candidate = await _context.Candidate.FindAsync(candidateLanguage.CandidateId);
            candidateLanguage.Candidate.User = await _context.User.FindAsync(candidateLanguage.Candidate.UserId);
            candidateLanguage.Candidate.Country = await _context.Country.FindAsync(candidateLanguage.Candidate.CountryId);
            candidateLanguage.Candidate.Other = await _context.Other.FindAsync(candidateLanguage.Candidate.OtherId);
            candidateLanguage.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidateLanguage.Candidate.Other.SalaryWishId);
            candidateLanguage.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidateLanguage.Candidate.Other.DrivingLicenceId);
            candidateLanguage.Language = await _context.Language.FindAsync(candidateLanguage.LanguageId);
            candidateLanguage.LanguageLevel = await _context.LanguageLevel.FindAsync(candidateLanguage.LanguageLevelId);
            if (candidateLanguage == null)
            {
                return NotFound();
            }

            return candidateLanguage;
        }

        // PUT: api/CandidateLanguages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateLanguage(int id, CandidateLanguage candidateLanguage)
        {
            if (id != candidateLanguage.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidateLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateLanguageExists(id))
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

        // POST: api/CandidateLanguages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CandidateLanguage>> PostCandidateLanguage(CandidateLanguage candidateLanguage)
        {
            candidateLanguage.Candidate = await _context.Candidate.FindAsync(candidateLanguage.CandidateId);
            candidateLanguage.Candidate.User = await _context.User.FindAsync(candidateLanguage.Candidate.UserId);
            candidateLanguage.Candidate.Country = await _context.Country.FindAsync(candidateLanguage.Candidate.CountryId);
            candidateLanguage.Candidate.Other = await _context.Other.FindAsync(candidateLanguage.Candidate.OtherId);
            candidateLanguage.Candidate.Other.SalaryWish = await _context.SalaryWish.FindAsync(candidateLanguage.Candidate.Other.SalaryWishId);
            candidateLanguage.Candidate.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(candidateLanguage.Candidate.Other.DrivingLicenceId);
            candidateLanguage.Language = await _context.Language.FindAsync(candidateLanguage.LanguageId);
            candidateLanguage.LanguageLevel = await _context.LanguageLevel.FindAsync(candidateLanguage.LanguageLevelId);
            _context.CandidateLanguage.Add(candidateLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateLanguage", new { id = candidateLanguage.Id }, candidateLanguage);
        }

        // DELETE: api/CandidateLanguages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateLanguage>> DeleteCandidateLanguage(int id)
        {
            var candidateLanguage = await _context.CandidateLanguage.FindAsync(id);
            if (candidateLanguage == null)
            {
                return NotFound();
            }

            _context.CandidateLanguage.Remove(candidateLanguage);
            await _context.SaveChangesAsync();

            return candidateLanguage;
        }

        private bool CandidateLanguageExists(int id)
        {
            return _context.CandidateLanguage.Any(e => e.Id == id);
        }
    }
}
