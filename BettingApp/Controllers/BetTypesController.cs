using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BettingApp.Data;
using BettingApp.Models;

namespace BettingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetTypesController : ControllerBase
    {
        private readonly BetDbContext _context;

        public BetTypesController(BetDbContext context)
        {
            _context = context;
        }

        // GET: api/BetTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BetType>>> GetBetTypes()
        {
            return await _context.BetTypes.ToListAsync();
        }

        // GET: api/BetTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BetType>> GetBetType(int id)
        {
            var betType = await _context.BetTypes.FindAsync(id);

            if (betType == null)
            {
                return NotFound();
            }

            return betType;
        }

        // PUT: api/BetTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBetType(int id, BetType betType)
        {
            if (id != betType.Id)
            {
                return BadRequest();
            }

            _context.Entry(betType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetTypeExists(id))
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

        // POST: api/BetTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BetType>> PostBetType(BetType betType)
        {
            _context.BetTypes.Add(betType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBetType", new { id = betType.Id }, betType);
        }

        // DELETE: api/BetTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBetType(int id)
        {
            var betType = await _context.BetTypes.FindAsync(id);
            if (betType == null)
            {
                return NotFound();
            }

            _context.BetTypes.Remove(betType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BetTypeExists(int id)
        {
            return _context.BetTypes.Any(e => e.Id == id);
        }
    }
}
