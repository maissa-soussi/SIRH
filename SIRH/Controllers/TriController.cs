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
    public class TriController : ControllerBase
    {
        private readonly SIRHContext _context;
        public TriController(SIRHContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<List<Candidature>> GetStatusAsync(Tri t)
        {
            List<Candidature> liste = new List<Candidature>();
            List<Candidature> candidatures=await _context.Candidature.Where(p => p.JobOfferId == t.id).ToListAsync();
            //List<int> idCandidats=t.idcandidats;
          /* while(t.idcandidats.Count!=0)
            {
                var candidate = await _context.Candidate.FindAsync(t.idcandidats[0]);
                liste.Add(candidate);
                t.idcandidats.RemoveAt(0);
            }*/
          foreach (Candidature candidature in candidatures)
             {
                if (t.idcandidats.Contains(candidature.CandidateId))
                {
                    candidature.Candidate = await _context.Candidate.FindAsync(candidature.CandidateId);
                    candidature.Status = await _context.Status.FindAsync(candidature.StatusId);
                    candidature.Candidate.User = await _context.User.FindAsync(candidature.Candidate.UserId);
                    candidature.Candidate.Country = await _context.Country.FindAsync(candidature.Candidate.CountryId);
                    candidature.Candidate.SalaryWish = await _context.SalaryWish.FindAsync(candidature.Candidate.SalaryWishId);
                    candidature.Candidate.DrivingLicence = await _context.DrivingLicence.FindAsync(candidature.Candidate.DrivingLicenceId);
                    candidature.JobOffer = await _context.JobOffer.FindAsync(candidature.JobOfferId);
                    candidature.JobOffer.Country = await _context.Country.FindAsync(candidature.JobOffer.CountryId);
                    candidature.JobOffer.Diploma = await _context.Diploma.FindAsync(candidature.JobOffer.DiplomaId);
                    candidature.JobOffer.Experience = await _context.Experience.FindAsync(candidature.JobOffer.ExperienceId);
                    candidature.JobOffer.ContratType = await _context.ContratType.FindAsync(candidature.JobOffer.ContratTypeId);
                    candidature.JobOffer.Domain = await _context.Domain.FindAsync(candidature.JobOffer.DomainId);
                    liste.Add(candidature);
                }
            }
            return liste;
        }
    }
}
