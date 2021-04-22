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
    public class CandidateDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CandidateDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDTO>> GetCandidateDTO(int id)
        {
            Candidate Candidate = await _context.Candidate.FindAsync(id);
            CandidateDTO CandidateDTO = new CandidateDTO();
            List<CandidateExperience> candidateExperiences = await _context.CandidateExperience.ToListAsync();
            List<Other> others = await _context.Other.ToListAsync();


            foreach (CandidateExperience ca in candidateExperiences)
            {
                if (ca.CandidateId == id)
                    CandidateDTO.ExperienceId = ca.ExperienceId;
            }
            foreach (Other o in others)
            {
                if (o.Id == Candidate.OtherId)
                {
                    CandidateDTO.DrivingLicenceId = o.DrivingLicenceId;
                    CandidateDTO.SalaryWishId = o.SalaryWishId;
                }
            }

            return CandidateDTO;
        }
    }
}
