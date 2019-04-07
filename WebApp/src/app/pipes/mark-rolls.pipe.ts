import { Pipe, PipeTransform } from '@angular/core';
import { RoundRolls } from '../data/models/round-rolls';

@Pipe({
  name: 'markRolls'
})
export class MarkRollsPipe implements PipeTransform {

  transform(value: RoundRolls, _args?: any): string {
    const maxPinCount = 10
    if(value.firstRoll == maxPinCount) {
      return 'X'
    }else if(value.firstRoll + value.secondRoll == maxPinCount) {
      return `${value.firstRoll} /`
    }else {
      return `${value.firstRoll} ${value.secondRoll}`
    }
  }

}
