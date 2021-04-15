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
    public class JobOfferDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public JobOfferDTOController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/CandidateExperiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOfferDTO>>> GetJobOfferDTO()
        {
            List<Candidature> candidatures = await _context.Candidature.ToListAsync();
            List<JobOffer> joboffers = await _context.JobOffer.ToListAsync();
            List<CandidateExperience> candidateexperiences = await _context.CandidateExperience.ToListAsync();
            List<CandidateDiploma> candidatediplomas = await _context.CandidateDiploma.ToListAsync();
            List<CandidateLanguage> candidatelanguages = await _context.CandidateLanguage.ToListAsync();
            List<CandidatureDTO> candidatureDTOs = new List<CandidatureDTO>();
            List<JobOfferDTO> jobOfferDTOs = new List<JobOfferDTO>();
            foreach (Candidature ca in candidatures)
            {
                CandidatureDTO c = new CandidatureDTO();
                String jdate = ca.JobInterviewDate;
                String cdate = ca.CandidatureDate;
                string lpath = ca.CoverLetterPath;
                int jid = (int)ca.JobOfferId;
                Candidate can = await _context.Candidate.FindAsync(ca.CandidateId);
                can.User = await _context.User.FindAsync(can.UserId);
                can.Country = await _context.Country.FindAsync(can.CountryId);
                can.Other = await _context.Other.FindAsync(can.OtherId);
                can.Other.SalaryWish = await _context.SalaryWish.FindAsync(can.Other.SalaryWishId);
                can.Other.DrivingLicence = await _context.DrivingLicence.FindAsync(can.Other.DrivingLicenceId);
                List<Experience> Exp = new List<Experience>();
                foreach (CandidateExperience ce in candidateexperiences)
                {
                    if (ce.CandidateId == ca.CandidateId)
                    {
                        Experience e = await _context.Experience.FindAsync(ce.ExperienceId);
                        Exp.Add(e);
                    }
                }
                List<Diploma> Dip = new List<Diploma>();
                foreach (CandidateDiploma cd in candidatediplomas)
                {
                    if (cd.CandidateId == ca.CandidateId)
                    {
                        Diploma d = await _context.Diploma.FindAsync(cd.DiplomaId);
                        Dip.Add(d);
                    }
                }
                List<CandidateLanguageDTO> Lan = new List<CandidateLanguageDTO>();
                foreach (CandidateLanguage cl in candidatelanguages)
                {
                    if (cl.CandidateId == ca.CandidateId)
                    {
                        CandidateLanguageDTO candl = new CandidateLanguageDTO();
                        Language l = await _context.Language.FindAsync(cl.LanguageId);
                        LanguageLevel ll = await _context.LanguageLevel.FindAsync(cl.LanguageLevelId);
                        candl.Language = l;
                        candl.LanguageLevel = ll;
                        Lan.Add(candl);
                    }
                }
                c.JobInterviewDate = jdate;
                c.CandidatureDate = cdate;
                c.CoverLetterPath = lpath;
                c.JobOfferId = jid;
                c.Candidate = can;
                c.Experiences = Exp;
                c.Languages = Lan;
                c.Diplomas = Dip;
                candidatureDTOs.Add(c);
            }
            foreach (JobOffer jo in joboffers)
            {
                JobOfferDTO j = new JobOfferDTO();
                JobOffer offer = await _context.JobOffer.FindAsync(jo.Id);
                offer.Country = await _context.Country.FindAsync(offer.CountryId);
                offer.Diploma = await _context.Diploma.FindAsync(offer.DiplomaId);
                offer.Experience = await _context.Experience.FindAsync(offer.ExperienceId);
                offer.ContratType = await _context.ContratType.FindAsync(offer.ContratTypeId);
                offer.Currency = await _context.Currency.FindAsync(offer.CurrencyId);
                List<CandidatureDTO> CDTO = new List<CandidatureDTO>();
                foreach (CandidatureDTO cand in candidatureDTOs)
                {
                    if (cand.JobOfferId == jo.Id)
                        CDTO.Add(cand);
                }
                j.JobOffer = offer;
                j.CandidatureDTOs = CDTO;
                jobOfferDTOs.Add(j);
            }
            return jobOfferDTOs;
        }
    }
}
