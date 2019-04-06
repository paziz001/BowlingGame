using System.Collections.Generic;
using FluentAssertions;
using Web.Api.Domain;
using Web.Api.Domain.Models;
using Xunit;

namespace Web.Api.Tests.UnitTests
{
    public class RoundScoresCalculatorTests
    {
        [Fact]
        public void CalculateScoresCorrectlyForOpenAndSpare()
        {
            var rounds = new List<Round>
            {
                new Round(4, 4, new RoundScore(false, 0)),
                new Round(10, 0, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
               new RoundScore(true, 8),
               new RoundScore(false, 0)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForThreeConsecutiveStrikes()
        {
            var rounds = new List<Round>
            {
                new Round(10, 0, new RoundScore(false, 0)),
                new Round(10, 0, new RoundScore(false, 0)),
                new Round(10, 0, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 30),
                new RoundScore(false, 0),
                new RoundScore(false, 0)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForTwoStrikesAndSpare()
        {
            var rounds = new List<Round>
            {
                new Round(10, 0, new RoundScore(false, 0)),
                new Round(10, 0, new RoundScore(false, 0)),
                new Round(5, 3, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 25),
                new RoundScore(true, 18),
                new RoundScore(true, 8)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForTwoStrikesAndOpen()
        {
            var rounds = new List<Round>
            {
                new Round(10, 0, new RoundScore(false, 0)),
                new Round(5, 2, new RoundScore(false, 0)),
                new Round(10, 0, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 17),
                new RoundScore(true, 7),
                new RoundScore(false, 0)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForStrikeAndOpen()
        {
            var rounds = new List<Round>
            {
                new Round(10, 0, new RoundScore(false, 0)),
                new Round(5, 2, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 17),
                new RoundScore(true, 7)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForStrikeAndSpare()
        {
            var rounds = new List<Round>
            {
                new Round(10, 0, new RoundScore(false, 0)),
                new Round(5, 5, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 20),
                new RoundScore(false, 0)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForStrike()
        {
            var rounds = new List<Round>
            {
                new Round(10, 0, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(false, 0)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForSpare()
        {
            var rounds = new List<Round>
            {
                new Round(3, 7, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(false, 0)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForOpen()
        {
            var rounds = new List<Round>
            {
                new Round(1, 0, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 1)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculateScoresCorrectlyForSpareAndStrike()
        {
            var rounds = new List<Round>
            {
                new Round(3, 7, new RoundScore(false, 0)),
                new Round(10, 0, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 20),
                new RoundScore(false, 0)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public void CalculatesForSpareAndOpen()
        {
            var rounds = new List<Round>
            {
                new Round(3, 7, new RoundScore(false, 0)),
                new Round(0, 7, new RoundScore(false, 0))
            };
            var expectedScores = new List<RoundScore>
            {
                new RoundScore(true, 10),
                new RoundScore(true, 7)
            };
            
            RoundScoresCalculator.Calculate(rounds).Should().BeEquivalentTo(expectedScores);
        }
    }
}