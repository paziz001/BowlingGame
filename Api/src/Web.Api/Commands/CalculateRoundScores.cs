using System.Collections.Generic;

namespace Web.Api.Commands
{
    public class CalculateRoundScores
    {
        public IEnumerable<(int FirstRoll, int SecondRoll)> Rounds { get; set; }
    }
}