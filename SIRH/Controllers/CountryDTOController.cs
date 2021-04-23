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
    public class CountryDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public CountryDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetCountryDTO(int id)
        {
            Country country = await _context.Country.FindAsync(id);
            List<int?> CandidateIDs = new List<int?>();
            List<Candidate> candidates = await _context.Candidate.ToListAsync();
            CountryDTO CountryDTO = new CountryDTO();
            CountryDTO.Country = country;
            foreach (Candidate ca in candidates)
            {
                if (ca.CountryId == country.Id)
                    CandidateIDs.Add(ca.Id);
            }
            CountryDTO.CandidateIDs = CandidateIDs;
            return CountryDTO;
        }
    }
}
