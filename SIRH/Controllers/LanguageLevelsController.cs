﻿using System;
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
    public class LanguageLevelsController : ControllerBase
    {
        private readonly SIRHContext _context;

        public LanguageLevelsController(SIRHContext context)
        {
            _context = context;
        }

        // GET: api/LanguageLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageLevel>>> GetLanguageLevel()
        {
            return await _context.LanguageLevel.ToListAsync();
        }

        // GET: api/LanguageLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageLevel>> GetLanguageLevel(int id)
        {
            var languageLevel = await _context.LanguageLevel.FindAsync(id);

            if (languageLevel == null)
            {
                return NotFound();
            }

            return languageLevel;
        }

        // PUT: api/LanguageLevels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguageLevel(int id, LanguageLevel languageLevel)
        {
            if (id != languageLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(languageLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageLevelExists(id))
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

        // POST: api/LanguageLevels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LanguageLevel>> PostLanguageLevel(LanguageLevel languageLevel)
        {
            _context.LanguageLevel.Add(languageLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguageLevel", new { id = languageLevel.Id }, languageLevel);
        }

        // DELETE: api/LanguageLevels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LanguageLevel>> DeleteLanguageLevel(int id)
        {
            var languageLevel = await _context.LanguageLevel.FindAsync(id);
            if (languageLevel == null)
            {
                return NotFound();
            }

            _context.LanguageLevel.Remove(languageLevel);
            await _context.SaveChangesAsync();

            return languageLevel;
        }

        private bool LanguageLevelExists(int id)
        {
            return _context.LanguageLevel.Any(e => e.Id == id);
        }
    }
}
