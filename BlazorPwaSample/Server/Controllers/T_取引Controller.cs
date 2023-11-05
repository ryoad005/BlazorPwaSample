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
    public class T_取引Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public T_取引Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/T_取引
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T_取引>>> GetT_取引()
        {
          if (_context.T_取引 == null)
          {
              return NotFound();
          }
            return await _context.T_取引.ToListAsync();
        }

        // GET: api/T_取引/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T_取引>> GetT_取引(int id)
        {
          if (_context.T_取引 == null)
          {
              return NotFound();
          }
            var t_取引 = await _context.T_取引.FindAsync(id);

            if (t_取引 == null)
            {
                return NotFound();
            }

            return t_取引;
        }

        // PUT: api/T_取引/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutT_取引(int id, T_取引 t_取引)
        {
            if (id != t_取引.Id)
            {
                return BadRequest();
            }

            _context.Entry(t_取引).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_取引Exists(id))
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

        // POST: api/T_取引
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<T_取引>> PostT_取引(T_取引 t_取引)
        {
          if (_context.T_取引 == null)
          {
              return Problem("Entity set 'AppDbContext.T_取引'  is null.");
          }
            _context.T_取引.Add(t_取引);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetT_取引", new { id = t_取引.Id }, t_取引);
        }

        // DELETE: api/T_取引/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteT_取引(int id)
        {
            if (_context.T_取引 == null)
            {
                return NotFound();
            }
            var t_取引 = await _context.T_取引.FindAsync(id);
            if (t_取引 == null)
            {
                return NotFound();
            }

            _context.T_取引.Remove(t_取引);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool T_取引Exists(int id)
        {
            return (_context.T_取引?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
