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
    public class MyCandidaturesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public  MyCandidaturesController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Candidature>>> GetCandidatures(int id)
        {
            try
            {
                var candidate = await _context.Candidate.Where(p => p.UserId == id).FirstAsync();
               
                    var candidatures = await _context.Candidature.Where(p => p.CandidateId == candidate.Id).ToListAsync();
                    foreach (Candidature ca in candidatures)
                    {
                        ca.Candidate = await _context.Candidate.FindAsync(ca.CandidateId);
                        ca.Status = await _context.Status.FindAsync(ca.StatusId);
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
                        ca.JobOffer.Domain = await _context.Domain.FindAsync(ca.JobOffer.DomainId);

                    }
                    return candidatures;
                
            }
            catch (InvalidOperationException)
            {
                return null;
            }

        }
    }
}

