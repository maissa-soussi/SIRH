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
    public class JobOffersController : ControllerBase
    {
        private readonly SIRHContext _context;

        public JobOffersController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/JobOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOffer>>> GetJobOffer()
        {
            List<JobOffer> jobOffers = await _context.JobOffer.ToListAsync();
            foreach (JobOffer jo in jobOffers)
            {
                jo.Country = await _context.Country.FindAsync(jo.CountryId);
                jo.Diploma = await _context.Diploma.FindAsync(jo.DiplomaId);
                jo.Experience = await _context.Experience.FindAsync(jo.ExperienceId);
                jo.ContratType = await _context.ContratType.FindAsync(jo.ContratTypeId);
                jo.Currency = await _context.Currency.FindAsync(jo.CurrencyId);
            }
            return jobOffers;
        }

        // GET: api/JobOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOffer>> GetJobOffer(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);
            jobOffer.Country = await _context.Country.FindAsync(jobOffer.CountryId);
            jobOffer.Diploma = await _context.Diploma.FindAsync(jobOffer.DiplomaId);
            jobOffer.Experience = await _context.Experience.FindAsync(jobOffer.ExperienceId);
            jobOffer.ContratType = await _context.ContratType.FindAsync(jobOffer.ContratTypeId);
            jobOffer.Currency = await _context.Currency.FindAsync(jobOffer.CurrencyId);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return jobOffer;
        }

        // PUT: api/JobOffers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOffer(int id, JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobOffers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobOffer>> PostJobOffer(JobOffer jobOffer)
        {
            jobOffer.Country = await _context.Country.FindAsync(jobOffer.CountryId);
            jobOffer.Diploma = await _context.Diploma.FindAsync(jobOffer.DiplomaId);
            jobOffer.Experience = await _context.Experience.FindAsync(jobOffer.ExperienceId);
            jobOffer.ContratType = await _context.ContratType.FindAsync(jobOffer.ContratTypeId);
            jobOffer.Currency = await _context.Currency.FindAsync(jobOffer.CurrencyId);
            _context.JobOffer.Add(jobOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobOffer", new { id = jobOffer.Id }, jobOffer);
        }

        // DELETE: api/JobOffers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobOffer>> DeleteJobOffer(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffer.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return jobOffer;
        }

        private bool JobOfferExists(int id)
        {
            return _context.JobOffer.Any(e => e.Id == id);
        }
    }
}
