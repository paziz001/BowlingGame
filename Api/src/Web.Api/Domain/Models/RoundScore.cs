namespace Web.Api.Domain.Models
{
    public struct RoundScore
    {
        public bool IsCalculated { get; }
        public int Value { get; }
        
        public RoundScore(bool isCalculated, int value)
        {
            IsCalculated = isCalculated;
            Value = value;
        }
    }
}