using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingApp.Models
{
    public static class BetConversion
    {
        public static BetDTO ToDTO(this Bet bet)
        {
            return new BetDTO
            {
                Amount = bet.Amount,
                Player = bet.Player,
                BetType = bet.BetType,
                PlayerUserName = bet.PlayerUserName,
                BetTypeId = bet.BetTypeId
            };
        }
        public static Bet ToModel(this CreateBetDTO createBet)
        {
            return new Bet
            {
                Amount = createBet.Amount,
                PlayerUserName = createBet.PlayerUserName,
                BetTypeId = createBet.BetTypeId,
                StartDate = DateTime.Now,
                UpdateTime = DateTime.Now
                
            };
        }
    }
}
