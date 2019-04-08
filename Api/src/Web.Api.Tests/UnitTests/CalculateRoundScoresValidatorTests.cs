using System.Linq;
using FluentValidation.TestHelper;
using Web.Api.Commands;
using Web.Api.Validators;
using Xunit;

namespace Web.Api.Tests.UnitTests
{
    public class CalculateRoundScoresValidatorTests: IClassFixture<CalculateRoundScoresValidator>
    {
        private readonly CalculateRoundScoresValidator _validator;

        public CalculateRoundScoresValidatorTests(CalculateRoundScoresValidator validator)
        {
            _validator = validator;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        public void ShouldHaveValidationErrorForOutOfRangeRoundsCount(int roundsCount)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = 10,
                    SecondRoll = 0
                }, roundsCount)
            };

            _validator.ShouldHaveValidationErrorFor(scores => scores.Rounds.Count(), calculateRoundScores);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(12)]
        public void ShouldNotHaveValidationErrorForValidRoundsCount(int roundsCount)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = 10,
                    SecondRoll = 0
                }, roundsCount)
            };

            _validator.ShouldNotHaveValidationErrorFor(scores => scores.Rounds.Count(), calculateRoundScores);
        }
        
        [Theory]
        [InlineData(-1, 10)]
        [InlineData(11, 5)]
        [InlineData(10, -1)]
        [InlineData(5, 11)]
        public void ShouldHaveValidationErrorForOutOfRangeRollValues(int firstRoll, int secondRoll)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = firstRoll,
                    SecondRoll = secondRoll
                }, 2)
            };

            _validator.ShouldHaveValidationErrorFor(scores => scores.Rounds, calculateRoundScores);
        }
        
        [Theory]
        [InlineData(0, 10)]
        [InlineData(3, 5)]
        [InlineData(10, 0)]
        [InlineData(5, 3)]
        public void ShouldNotHaveValidationErrorForValidRollValues(int firstRoll, int secondRoll)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = firstRoll,
                    SecondRoll = secondRoll
                }, 2)
            };

            _validator.ShouldNotHaveValidationErrorFor(scores => scores.Rounds, calculateRoundScores);
        }
        
        [Fact]
        public void ShouldHaveValidationErrorForOutOfRangeRollValueSums()
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = 10,
                    SecondRoll = 10
                }, 2)
            };

            _validator.ShouldHaveValidationErrorFor(scores => scores.Rounds, calculateRoundScores);
        }
        
        [Theory]
        [InlineData(0, 10)]
        [InlineData(0, 0)]
        [InlineData(10, 0)]
        [InlineData(5, 3)]
        public void ShouldNotHaveValidationErrorForValidRollValueSums(int firstRoll, int secondRoll)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = firstRoll,
                    SecondRoll = secondRoll
                }, 2)
            };

            _validator.ShouldNotHaveValidationErrorFor(scores => scores.Rounds, calculateRoundScores);
        }
        
        [Theory]
        [InlineData(0, 5)]
        [InlineData(9, 0)]
        [InlineData(1, 4)]
        [InlineData(3, 3)]
        public void ShouldHaveValidationErrorForInvalidRoundsWhenCalculatingElevenRounds(int firstRollForTenthRound, int secondRollForTenthRound)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = 10,
                    SecondRoll = 0
                }, 9)
            };
            calculateRoundScores.Rounds = calculateRoundScores.Rounds.Concat(new[]
            {
                new RoundRolls
                {
                    FirstRoll = firstRollForTenthRound,
                    SecondRoll = secondRollForTenthRound
                },
                new RoundRolls
                {
                    FirstRoll = 5,
                    SecondRoll = 0
                }
            });
            _validator.ShouldHaveValidationErrorFor(scores => scores.Rounds.ToList(), calculateRoundScores);
        }
        
        [Theory]
        [InlineData(5, 5)]
        [InlineData(10, 0)]
        [InlineData(0, 10)]
        [InlineData(7, 3)]
        public void ShouldHaveNotValidationErrorForValidRoundsWhenCalculatingElevenRounds(int firstRollForTenthRound, int secondRollForTenthRound)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = 10,
                    SecondRoll = 0
                }, 9)
            };
            calculateRoundScores.Rounds = calculateRoundScores.Rounds.Concat(new[]
            {
                new RoundRolls
                {
                    FirstRoll = firstRollForTenthRound,
                    SecondRoll = secondRollForTenthRound
                },
                new RoundRolls
                {
                    FirstRoll = 5,
                    SecondRoll = 5
                }
            });
            _validator.ShouldHaveValidationErrorFor(scores => scores.Rounds.ToList(), calculateRoundScores);
        }
        
        [Theory]
        [InlineData(5, 4, 10, 0)]
        [InlineData(10, 0, 5, 4)]
        public void ShouldHaveValidationErrorForInvalidRoundsWhenCalculatingTwelveRounds(
            int firstRollForRoundTen, int secondRollForRoundTen, int firstRollForRoundEleven, int secondRollForRoundEleven)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = 10,
                    SecondRoll = 0
                }, 10)
            };
            calculateRoundScores.Rounds = calculateRoundScores.Rounds.Concat(new[]
            {
                new RoundRolls
                {
                    FirstRoll = firstRollForRoundTen,
                    SecondRoll = secondRollForRoundTen
                },
                new RoundRolls
                {
                    FirstRoll = firstRollForRoundEleven,
                    SecondRoll = secondRollForRoundEleven
                }
            });
            _validator.ShouldHaveValidationErrorFor(scores => scores.Rounds.ToList(), calculateRoundScores);
        }
        
        [Theory]
        [InlineData(0, 0)]
        [InlineData(6, 0)]
        [InlineData(9, 0)]
        [InlineData(10, 0)]
        public void ShouldNotHaveValidationErrorForValidRoundsWhenCalculatingTwelveRounds(int firstRollForRoundEleven, int secondRollForRoundEleven)
        {
            var calculateRoundScores = new CalculateRoundScores
            {
                Rounds = Enumerable.Repeat(new RoundRolls
                {
                    FirstRoll = 10,
                    SecondRoll = 0
                }, 11)
            };
            calculateRoundScores.Rounds = calculateRoundScores.Rounds.Concat(new[]
            {
                new RoundRolls
                {
                    FirstRoll = firstRollForRoundEleven,
                    SecondRoll = secondRollForRoundEleven
                }
            });
            
            _validator.ShouldNotHaveValidationErrorFor(scores => scores.Rounds.ToList(), calculateRoundScores);
        }
    }
}