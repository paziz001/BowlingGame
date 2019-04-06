using System.Collections.Generic;
using System.Linq;
using Web.Api.Domain;
using Web.Api.Domain.Models;

namespace Web.Api.Commands
{
    public class CommandHandler
    {
        public IEnumerable<RoundScore> Handle(CalculateRoundScores calculateRoundScores)
        {
            return RoundScoresCalculator.Calculate(GetRoundsFrom(calculateRoundScores));
        }

        private static IList<Round> GetRoundsFrom(CalculateRoundScores calculateRoundScores)
        {
            return calculateRoundScores.Rounds.Select(round =>
                new Round(round.FirstRoll, round.SecondRoll, new RoundScore(false, 0))).ToList();
        }
    }
}