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
    public class GetCandidateController : ControllerBase
    {
        private readonly SIRHContext _context;

        public GetCandidateController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidatById(int id)
        {
            Candidate c = new Candidate();
            try
            {
                var candidate = await _context.Candidate.FirstAsync(p => p.UserId == id);
                    candidate.User = await _context.User.FindAsync(candidate.UserId);
                    candidate.Country = await _context.Country.FindAsync(candidate.CountryId);
                    candidate.SalaryWish = await _context.SalaryWish.FindAsync(candidate.SalaryWishId);
                    candidate.DrivingLicence = await _context.DrivingLicence.FindAsync(candidate.DrivingLicenceId);
                    return candidate;
                
            }
            catch (InvalidOperationException)
            {
                return c;
            }
                
            
            
        }
    }
}
