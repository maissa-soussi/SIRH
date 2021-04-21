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
    public class JobOfferDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public JobOfferDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOfferDTO>> GetJobOfferDTO(int id)
        {
            JobOffer JobOffer = await _context.JobOffer.FindAsync(id);
            List<int?> CandidateIDs = new List<int?>();
            List<Candidature> candidature= await _context.Candidature.ToListAsync();
            JobOfferDTO JobOfferDTO = new JobOfferDTO();
            JobOfferDTO.JobOffer = JobOffer;
            foreach (Candidature ca in candidature)
            {
                if (ca.JobOfferId == JobOffer.Id)
                    CandidateIDs.Add(ca.CandidateId);
            }
            JobOfferDTO.CandidateIDs = CandidateIDs;
            return JobOfferDTO;
        }
    }
}

