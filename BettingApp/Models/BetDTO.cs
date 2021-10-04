using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingApp.Models
{
    public class BetDTO : CreateBetDTO
    {
        public Player Player { get; set; }
        public BetType BetType { get; set; }
    }
}
