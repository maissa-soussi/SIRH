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
    public class DiplomaDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public DiplomaDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DiplomaDTO>> GetDiplomaDTO(int id)
        {
            Diploma diploma = await _context.Diploma.FindAsync(id);
            List<int?> CandidateIDs = new List<int?>();
            List<CandidateDiploma> candidateDiplomas = await _context.CandidateDiploma.ToListAsync();
            DiplomaDTO DiplomaDTO = new DiplomaDTO();
            DiplomaDTO.Diploma = diploma;
            foreach (CandidateDiploma cd in candidateDiplomas)
            {
                if (cd.DiplomaId == diploma.Id)
                    CandidateIDs.Add(cd.CandidateId);
            }
            DiplomaDTO.CandidateIDs = CandidateIDs;

            return DiplomaDTO;
        }
    }
}
