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
    public class JobOfferCandidaturesController : ControllerBase
    {
        private readonly SIRHContext _context;

        public JobOfferCandidaturesController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<JobOfferCandidature>>> GetJobOfferCandidature(int id)
        {
            List<Candidature> candidatures = await _context.Candidature.ToListAsync();
            List<JobOfferCandidature> jobOfferCandidatures = new List<JobOfferCandidature>();
            foreach (Candidature ca in candidatures)
            {
                if (ca.JobOfferId == id)
                {
                    JobOfferCandidature jo = new JobOfferCandidature();
                    jo.JobInterviewDate = ca.JobInterviewDate;
                    jo.CandidatureDate = ca.CandidatureDate;
                    jo.CoverLetterPath = ca.CoverLetterPath;
                    jo.CandidateId = ca.CandidateId;
                    jo.Candidate = await _context.Candidate.FindAsync(ca.CandidateId);
                    jo.Candidate.User = await _context.User.FindAsync(jo.Candidate.UserId);
                    jo.StatusId = ca.StatusId;
                    jo.Status = await _context.Status.FindAsync(ca.StatusId);
                    jobOfferCandidatures.Add(jo);
                }
            }
            if (jobOfferCandidatures == null)
            {
                return NotFound();
            }
            return jobOfferCandidatures;
        }
    }
}
