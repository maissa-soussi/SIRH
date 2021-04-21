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
    public class LanguageDTOController : ControllerBase
    {
        private readonly SIRHContext _context;

        public LanguageDTOController(SIRHContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageDTO>> GetLanguageDTO(int id)
        {
            LanguageDTO languageDTO = new LanguageDTO();

            return languageDTO;
        }
    }
}

