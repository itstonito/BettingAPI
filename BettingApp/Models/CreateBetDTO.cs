using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingApp.Models
{
    public class CreateBetDTO
    {   
        public int Amount { get; set; }
        public int BetTypeId { get; set; }
        public string PlayerUserName { get; set; }

    }
}
