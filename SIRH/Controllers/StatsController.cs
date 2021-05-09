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

        [HttpGet("{id}")]
        public async Task<ActionResult<Stat>> GetStat(int id)
        {
            Stat stat = new Stat();
            stat.Candidats = 0;
            stat.Offres = 0;
            var candidat = await _context.Candidate.FindAsync(id);

            if (candidat == null)
            {
                stat.Candidatures = 0;
                stat.CandidatureSponts = 0;
            }
            else
            {
                List<Candidature> candidatures = await _context.Candidature.ToListAsync();
                List<CandidatureSpont> candidatureSponts = await _context.CandidatureSpont.ToListAsync();
                var nbcandidatures = 0;
                var nbcandidaturesponts = 0;
                foreach (Candidature ca in candidatures) {
                    if (ca.CandidateId == id)
                        nbcandidatures++;
                        }
                foreach (CandidatureSpont cp in candidatureSponts)
                {
                    if (cp.CandidateId == id)
                        nbcandidaturesponts++;
                }
                stat.Candidatures = nbcandidatures;
                stat.CandidatureSponts = nbcandidaturesponts;
            }

            return stat;
        }
    }
}
