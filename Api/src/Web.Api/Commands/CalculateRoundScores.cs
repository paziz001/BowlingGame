using System.Collections.Generic;

namespace Web.Api.Commands
{
    public class CalculateRoundScores
    {
        public IEnumerable<RoundRolls> Rounds { get; set; }
    }
    
    public class RoundRolls
    {
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
    }
}