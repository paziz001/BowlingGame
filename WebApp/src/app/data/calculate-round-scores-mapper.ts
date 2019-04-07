import { Round } from './models/round';
import { RoundRolls } from './models/round-rolls';
import { CalculateRoundScores } from './request-bodies/calculate-round-scores';

export class CalculateRoundScoresMapper {
  static From(rounds: Map<number, Round>): CalculateRoundScores {
    var roundsRolls = new Array<RoundRolls>();

    rounds.forEach(round =>
      roundsRolls.push(<RoundRolls> {
        firstRoll: round.rolls.firstRoll,
        secondRoll: round.rolls.secondRoll
    }));

    return <CalculateRoundScores> {
      rounds: roundsRolls
    };
  }
}
