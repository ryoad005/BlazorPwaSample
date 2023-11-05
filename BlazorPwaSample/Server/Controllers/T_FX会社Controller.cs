using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorPwaSample.Server.Data;
using BlazorPwaSample.Shared.Models;

namespace BlazorPwaSample.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class T_FX会社Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public T_FX会社Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/T_FX会社
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T_FX会社>>> GetT_FX会社()
        {
          if (_context.T_FX会社 == null)
          {
              return NotFound();
          }
            return await _context.T_FX会社.ToListAsync();
        }

        // GET: api/T_FX会社/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T_FX会社>> GetT_FX会社(int id)
        {
          if (_context.T_FX会社 == null)
          {
              return NotFound();
          }
            var t_FX会社 = await _context.T_FX会社.FindAsync(id);

            if (t_FX会社 == null)
            {
                return NotFound();
            }

            return t_FX会社;
        }

        // PUT: api/T_FX会社/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutT_FX会社(int id, T_FX会社 t_FX会社)
        {
            if (id != t_FX会社.Id)
            {
                return BadRequest();
            }

            _context.Entry(t_FX会社).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_FX会社Exists(id))
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

        // POST: api/T_FX会社
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<T_FX会社>> PostT_FX会社(T_FX会社 t_FX会社)
        {
          if (_context.T_FX会社 == null)
          {
              return Problem("Entity set 'AppDbContext.T_FX会社'  is null.");
          }
            _context.T_FX会社.Add(t_FX会社);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetT_FX会社", new { id = t_FX会社.Id }, t_FX会社);
        }

        // DELETE: api/T_FX会社/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteT_FX会社(int id)
        {
            if (_context.T_FX会社 == null)
            {
                return NotFound();
            }
            var t_FX会社 = await _context.T_FX会社.FindAsync(id);
            if (t_FX会社 == null)
            {
                return NotFound();
            }

            _context.T_FX会社.Remove(t_FX会社);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool T_FX会社Exists(int id)
        {
            return (_context.T_FX会社?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
