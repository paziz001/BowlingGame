import { Injectable } from '@angular/core';
import { Round } from '../../data/models/round';

@Injectable({
  providedIn: 'root'
})
export class RoundCacheService {
  private _rounds: Map<number, Round> = new Map<number, Round>();

  get rounds() {
    return this._rounds;
  }

  constructor() { }

  set(index: number, round: Round) {
    this._rounds.set(index, round);
  }

  get(index: number) {
    return this._rounds.get(index);
  }

  values(): Array<Round> {
    let array = new Array<Round>();
    this._rounds.forEach(value => array.push(value));

    return array;
  }

  clear() {
    this._rounds = new Map<number, Round>();
  }
}
