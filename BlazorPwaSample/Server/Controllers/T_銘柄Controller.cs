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
    public class T_銘柄Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public T_銘柄Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/T_銘柄
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T_銘柄>>> GetT_銘柄()
        {
          if (_context.T_銘柄 == null)
          {
              return NotFound();
          }
            return await _context.T_銘柄.ToListAsync();
        }

        // GET: api/T_銘柄/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T_銘柄>> GetT_銘柄(int id)
        {
          if (_context.T_銘柄 == null)
          {
              return NotFound();
          }
            var t_銘柄 = await _context.T_銘柄.FindAsync(id);

            if (t_銘柄 == null)
            {
                return NotFound();
            }

            return t_銘柄;
        }

        // PUT: api/T_銘柄/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutT_銘柄(int id, T_銘柄 t_銘柄)
        {
            if (id != t_銘柄.Id)
            {
                return BadRequest();
            }

            _context.Entry(t_銘柄).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_銘柄Exists(id))
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

        // POST: api/T_銘柄
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<T_銘柄>> PostT_銘柄(T_銘柄 t_銘柄)
        {
          if (_context.T_銘柄 == null)
          {
              return Problem("Entity set 'AppDbContext.T_銘柄'  is null.");
          }
            _context.T_銘柄.Add(t_銘柄);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetT_銘柄", new { id = t_銘柄.Id }, t_銘柄);
        }

        // DELETE: api/T_銘柄/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteT_銘柄(int id)
        {
            if (_context.T_銘柄 == null)
            {
                return NotFound();
            }
            var t_銘柄 = await _context.T_銘柄.FindAsync(id);
            if (t_銘柄 == null)
            {
                return NotFound();
            }

            _context.T_銘柄.Remove(t_銘柄);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool T_銘柄Exists(int id)
        {
            return (_context.T_銘柄?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
