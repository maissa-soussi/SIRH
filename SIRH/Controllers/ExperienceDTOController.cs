using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIRH.Data;
using SIRH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public ExperienceDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienceDTO>> GetExperienceDTO(int id)
        {
            Experience experience = await _context.Experience.FindAsync(id);
            List<int?> CandidateIDs = new List<int?>();
            List<CandidateExperience> candidateExperiences= await _context.CandidateExperience.ToListAsync();
           ExperienceDTO experienceDTO = new ExperienceDTO();
            experienceDTO.Experience = experience;
            foreach (CandidateExperience ca in candidateExperiences)
            {
                if (ca.Experience.Name == experience.Name)
                    CandidateIDs.Add(ca.CandidateId);
            }
            experienceDTO.CandidateIDs = CandidateIDs;
            return experienceDTO;
        }

    }
}
