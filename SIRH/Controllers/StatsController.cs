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
    public class StatsController : ControllerBase
    {
        private readonly SIRHContext _context;
        public StatsController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Stat>> GetStat()
        {
            Stat stat = new Stat();
            List<Candidate> c= await _context.Candidate.ToListAsync();
            stat.Candidats = c.Count();
            List<JobOffer> offres = await _context.JobOffer.ToListAsync();
            stat.Offres = offres.Count();
            List<Candidature> candidatures = await _context.Candidature.ToListAsync();
            stat.Candidatures = candidatures.Count();
            List<CandidatureSpont> candidatureSponts = await _context.CandidatureSpont.ToListAsync();
            stat.CandidatureSponts = candidatureSponts.Count();

            return stat;
        }
    }
}
