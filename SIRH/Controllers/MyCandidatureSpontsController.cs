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
    public class MyCandidatureSpontsController : ControllerBase
    {
        private readonly SIRHContext _context;

        public MyCandidatureSpontsController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CandidatureSpont>>> GetCandidatures(int id)
        {
            try
            {
                var candidate = await _context.Candidate.Where(p => p.UserId == id).FirstAsync();

                var candidatures = await _context.CandidatureSpont.Where(p => p.CandidateId == candidate.Id).ToListAsync();
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
            catch (InvalidOperationException)
            {
                return null;
            }

        }
    }
}
