import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { RoundRolls } from '../../data/models/round-rolls';
import { RoundScore } from '../../data/models/round-score';

@Component({
  selector: 'app-round-score-cell',
  templateUrl: './round-score-cell.component.html',
  styleUrls: ['./round-score-cell.component.css']
})
export class RoundScoreCellComponent {
  @Input() rolls: string;
  @Input() score: string;

  constructor() { }
}
