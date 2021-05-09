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
    public class EducationLevelDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public EducationLevelDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationLevelDTO>> GetEducationLevelDTO(int id)
        {
            EducationLevel educationLevel = await _context.EducationLevel.FindAsync(id);
            List<int?> CandidateIDs = new List<int?>();
            List<CandidateDiploma> candidateDiplomas = await _context.CandidateDiploma.ToListAsync();
            EducationLevelDTO EducationLevelDTO = new EducationLevelDTO();
            EducationLevelDTO.EducationLevel = educationLevel;
            foreach (CandidateDiploma cd in candidateDiplomas)
            {
                if (cd.EducationLevelId == educationLevel.Id)
                    CandidateIDs.Add(cd.CandidateId);
            }
            EducationLevelDTO.CandidateIDs = CandidateIDs;
            return EducationLevelDTO;
        }
    }
}
