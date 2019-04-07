import { Pipe, PipeTransform } from '@angular/core';
import { RoundScore } from '../data/models/round-score';

@Pipe({
  name: 'hideRoundScore'
})
export class HideRoundScorePipe implements PipeTransform {

  transform(score: RoundScore, _args?: any): string {
    if(score.isCalculated) {
      return `${score.value}`;
    }else {
      return '';
    };
  }

}
