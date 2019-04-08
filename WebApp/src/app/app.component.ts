import { Component, OnDestroy, OnInit } from '@angular/core';
import { RollsSubmitted } from './data/events/rolls-submitted';
import { RoundScoreService } from './services/round-scores/round-score.service';
import { RoundCacheService } from './services/round-cache/round-cache.service';
import { RoundRolls } from './data/models/round-rolls';
import { CalculateRoundScoresMapper } from './data/calculate-round-scores-mapper';
import { CalculateRoundScores } from './data/request-bodies/calculate-round-scores';
import { RoundScore } from './data/models/round-score';
import { Round } from './data/models/round';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  rounds: Array<Round>;
  totalScore: number;
  gameFinished: boolean;
  constructor(private roundScoresService: RoundScoreService, private roundCacheService: RoundCacheService) {

  }

  ngOnInit(): void {
    this.initializeProperties();
  }

  onRollsSubmitted(rollsSubmitted: RollsSubmitted) {
    if(this.rounds.length == 9 && rollsSubmitted.firstRoll + rollsSubmitted.secondRoll < 10) {
      this.gameFinished = true;
    }
    if(this.rounds.length == 10 && this.rounds[9].rolls.firstRoll < 10 && rollsSubmitted.secondRoll == 0) {
      this.gameFinished = true;
    }
    if(this.rounds.length == 11 && rollsSubmitted.secondRoll == 0) {
      this.gameFinished = true;
    }
    this.roundScoresService.calculateRoundScores(this.constructServiceRequest(rollsSubmitted))
      .subscribe(
        (roundScores: Array<RoundScore>) => {
          roundScores.forEach((roundScore, index) => {
            let roundToEdit = this.roundCacheService.get(index);
            if(roundToEdit != null) {
              roundToEdit.score = roundScore;
            } else {
              this.roundCacheService.set(index, <Round> {
                index: index,
                rolls: {
                  firstRoll: rollsSubmitted.firstRoll,
                  secondRoll: rollsSubmitted.secondRoll
                },
                score: roundScore
              })
            }
          });
          this.rounds = this.roundCacheService.values();
          let calculatedScores = roundScores.filter(score => score.isCalculated).map(score => score.value);
          this.totalScore = calculatedScores[calculatedScores.length - 1]
        },
        error => console.error(error))
  }

  onGameReset() {
    this.roundCacheService.clear();
    this.initializeProperties();
  }

  private initializeProperties() {
    this.rounds = new Array<Round>();
    this.totalScore = 0;
    this.gameFinished = false;
  }

  private constructServiceRequest(rollsSubmitted: RollsSubmitted): CalculateRoundScores {
    let submittedRoundRolls = <RoundRolls> {
      firstRoll: rollsSubmitted.firstRoll,
      secondRoll: rollsSubmitted.secondRoll
    }

    let request: CalculateRoundScores = CalculateRoundScoresMapper.From(this.roundCacheService.rounds);
    request.rounds.push(submittedRoundRolls);

    return request;
  }
}
