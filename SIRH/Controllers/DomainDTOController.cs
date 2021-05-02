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
    public class DomainDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public DomainDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DomainDTO>> GetDomainDTO(int id)
        {
            Domain domain = await _context.Domain.FindAsync(id);
            List<int?> CandidateIDs = new List<int?>();
            List<CandidateExperience> candidateExperiences = await _context.CandidateExperience.ToListAsync();
            DomainDTO DomainDTO = new DomainDTO();
            DomainDTO.Domain = domain;
            foreach (CandidateExperience ca in candidateExperiences)
            {
                if (ca.DomainId == domain.Id)
                    CandidateIDs.Add(ca.CandidateId);
            }
            DomainDTO.CandidateIDs = CandidateIDs;
            return DomainDTO;
        }
    }
}
