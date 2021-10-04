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
    public class BetsController : ControllerBase
    {
        private readonly BetDbContext _context;

        public BetsController(BetDbContext context)
        {
            _context = context;
        }

        // GET: api/Bets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BetDTO>>> GetBets()
        {
            IEnumerable<Bet> bets = await _context.Bets.Include("Player").Include("BetType").ToListAsync();
            List<BetDTO> betDTOs = new List<BetDTO>();
            foreach (var bet in bets)
            { 
                betDTOs.Add(bet.ToDTO());
            }
            return betDTOs;
        }

        // GET: api/Bets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BetDTO>> GetBet(int id)
        {

            var bet =  await _context.Bets.Include("Player").Include("BetType").FirstOrDefaultAsync(b => b.Id == id);

            if (bet == null)
            {
                return NotFound();
            }
            return bet.ToDTO();
        }

        // PUT: api/Bets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBet(int id, PutBetDTO putBet)
        {
            if (id != putBet.Id)
            {
                return BadRequest();
            }


            var bet = await _context.Bets.Include("Player").Include("BetType").FirstOrDefaultAsync(b => b.Id == id);
            bet.Amount = putBet.Amount;
            bet.UpdateTime = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetExists(id))
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

        // POST: api/Bets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bet>> PostBet(CreateBetDTO createBet)
        {
            Bet bet = createBet.ToModel();
            bet.BetType = _context.BetTypes.FirstOrDefault(t => t.Id == createBet.BetTypeId);
            bet.Player = _context.Players.FirstOrDefault(p => p.UserName == createBet.PlayerUserName);

            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBet", new { id = bet.Id }, bet);
        }

        // DELETE: api/Bets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBet(int id)
        {
            var bet = await _context.Bets.FindAsync(id);
            if (bet == null)
            {
                return NotFound();
            }

            _context.Bets.Remove(bet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BetExists(int id)
        {
            return _context.Bets.Any(e => e.Id == id);
        }
    }
}
