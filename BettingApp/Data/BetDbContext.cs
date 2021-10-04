using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingApp.Models;

namespace BettingApp.Data
{
    public class BetDbContext : IdentityDbContext
    {
        public BetDbContext(DbContextOptions<BetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<BetType> BetTypes { get; set; }
        public DbSet<Bet> Bets{ get; set; }

    }
}
