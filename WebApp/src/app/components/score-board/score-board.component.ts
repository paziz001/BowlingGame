import { Component, Input, OnInit } from '@angular/core';
import { Round } from '../../data/models/round';
import { MarkRollsPipe } from '../../pipes/mark-rolls.pipe';
import { HideRoundScorePipe } from '../../pipes/hide-round-score.pipe';

@Component({
  selector: 'app-score-board',
  templateUrl: 'score-board.component.html',
  styleUrls: ['score-board.component.css'],
  providers: [MarkRollsPipe, HideRoundScorePipe]
})
export class ScoreBoardComponent {
  @Input() rounds: Array<Round>;
  @Input() totalScore: number
  headerNames: string[] = ['1','2', '3', '4', '5', '6', '7', '8', '9'];

  constructor(private rollsPipe: MarkRollsPipe, private scorePipe: HideRoundScorePipe) {

  }

  rollsForRound(roundIndex: number) {
    if(this.rounds[roundIndex] != null) {
      return this.rollsPipe.transform(this.rounds[roundIndex].rolls);
    }

    return '';
  }

  scoreForRound(roundIndex: number): string {
    if(this.rounds[roundIndex] != null) {
      return this.scorePipe.transform(this.rounds[roundIndex].score)
    }

    return '';
  }

  rollsForFinalRound(): string {
    let rolls = '';
    if(this.rounds.length > 9) {
      for (let i = 9; i < this.rounds.length; i++) {
        rolls += `${this.rollsPipe.transform(this.rounds[i].rolls)} `;
      }
    }

    return rolls;
  }

  scoreForFinalRound(): string {
    let score = '';
    if(this.rounds.length > 9) {
      score = `${this.scorePipe.transform(this.rounds[9].score)} `;
    }

    return score;
  }
}
