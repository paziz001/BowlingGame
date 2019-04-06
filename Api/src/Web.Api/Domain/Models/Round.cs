namespace Web.Api.Domain.Models
{
    public class Round
    {
        //private RoundMark _mark;
        public int FirstRoll { get; }
        public int SecondRoll { get; }
        public RoundScore Score { get; }
        public RoundMark Mark => GetMark();

        public Round(int firstRoll, int secondRoll, RoundScore score)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            Score = score;
        }

        private RoundMark GetMark()
        {
            if (FirstRoll == 10)
            {
                return RoundMark.Strike;
            }
            if (FirstRoll + SecondRoll == 10)
            {
                return RoundMark.Spare;
            }

            return RoundMark.Open;
        }
    }
}