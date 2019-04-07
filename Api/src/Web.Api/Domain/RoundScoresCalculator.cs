using System.Collections.Generic;
using System.Linq;
using Web.Api.Domain.Models;

namespace Web.Api.Domain
{
    public static class RoundScoresCalculator
    {
        public static IEnumerable<RoundScore> Calculate(IList<Round> rounds)
        {
            var updatedRounds = new List<Round>(rounds);
            for (var i = 0; i < rounds.Count; i++)
            {
                var previousRoundScore = i - 1 >= 0 ? updatedRounds[i - 1].Score.Value : 0;
                if (rounds[i].Mark == RoundMark.Strike)
                {
                    updatedRounds[i] = new Round(rounds[i].FirstRoll, rounds[i].SecondRoll, CalculateStrikeRound(rounds, i, previousRoundScore));
                }
                
                if (rounds[i].Mark == RoundMark.Spare)
                {
                    var roundScore = previousRoundScore + rounds[i].FirstRoll + rounds[i].SecondRoll;
                    if (i + 1 < rounds.Count)
                    {
                        roundScore += rounds[i + 1].FirstRoll;
                        updatedRounds[i] = new Round(rounds[i].FirstRoll, rounds[i].SecondRoll, new RoundScore(true, roundScore));
                    }
                }

                if (rounds[i].Mark == RoundMark.Open)
                {
                    var roundScore = previousRoundScore + rounds[i].FirstRoll + rounds[i].SecondRoll;
                    updatedRounds[i] = new Round(rounds[i].FirstRoll, rounds[i].SecondRoll, new RoundScore(true, roundScore));
                }
            }

            return updatedRounds.Select(round => round.Score);
        }

        private static RoundScore CalculateStrikeRound(IList<Round> rounds, int roundIndex, int previousRoundScore)
        {
            
            var roundScore = previousRoundScore + rounds[roundIndex].FirstRoll;
            var rollsScored = 0;
            const int strikeBonusRolls = 2;
            for (var j = roundIndex + 1; j <= roundIndex + strikeBonusRolls && rollsScored < strikeBonusRolls && j < rounds.Count; j++)
            {
                if (rounds[j].Mark == RoundMark.Strike)
                {
                    roundScore += rounds[j].FirstRoll;
                    rollsScored += 1;
                }
                else
                {
                    if (rollsScored == 1)
                    {
                        roundScore += rounds[j].FirstRoll;
                        rollsScored += 1;
                    }
                    else
                    {
                        roundScore += rounds[j].FirstRoll + rounds[j].SecondRoll;
                        rollsScored = strikeBonusRolls;
                    }
                }
            }

            return rollsScored < strikeBonusRolls ? new RoundScore(false, 0) : new RoundScore(true, roundScore);
        }
    }
}