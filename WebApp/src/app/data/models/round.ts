import { RoundRolls } from './round-rolls';
import { RoundScore } from './round-score';

export interface Round {
  index: number;
  rolls: RoundRolls;
  score: RoundScore;
}
