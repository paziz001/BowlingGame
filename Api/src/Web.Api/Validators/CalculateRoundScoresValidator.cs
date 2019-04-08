using System.Linq;
using FluentValidation;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Web.Api.Commands;

namespace Web.Api.Validators
{
    public class CalculateRoundScoresValidator: AbstractValidator<CalculateRoundScores>
    {
        public CalculateRoundScoresValidator()
        {
            RuleFor(x => x.Rounds.Count()).InclusiveBetween(1, 12)
                .WithMessage("Number of rounds must be from 1 to 12");
            RuleForEach(x => x.Rounds)
                .Must(round => (round.FirstRoll >= 0 && round.FirstRoll <= 10) &&
                               (round.SecondRoll >= 0 && round.SecondRoll <= 10))
                .WithMessage("Roll values must be between 0 and 10");
            RuleForEach(x => x.Rounds)
                .Must(round => (round.FirstRoll + round.SecondRoll <= 10) &&
                               (round.FirstRoll + round.SecondRoll >= 0))
                .WithMessage("Sum of roll values must be between 0 and 10");
            RuleFor(x => x.Rounds.ToList())
                .Custom((rounds, context) =>
                {
                    if (rounds.Count == 11 &&
                        (rounds[rounds.Count - 2].FirstRoll + rounds[rounds.Count - 2].SecondRoll < 10 ||
                        rounds[rounds.Count - 1].FirstRoll < 10 && rounds[rounds.Count - 1].SecondRoll > 0))
                    {
                        context.AddFailure(
                            "10th round must be a spare or a strike in order for the 11th round to be calculated." +
                            "When the 10th round is a spare then the eleventh round second roll should be 0");
                    }
                });
            RuleFor(x => x.Rounds.ToList())
                .Custom((rounds, context) =>
                {
                    if (rounds.Count == 12 &&
                        (rounds[rounds.Count - 3].FirstRoll < 10 || rounds[rounds.Count - 2].FirstRoll < 10 ||
                        rounds[rounds.Count - 1].FirstRoll < 10 && rounds[rounds.Count - 1].SecondRoll > 0))
                    {
                        context.AddFailure(
                            "10th and 11th round must be strikes in order for the 12th round to be calculated");
                    }
                });
        }
    }
}