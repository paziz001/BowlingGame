import { Component, Output, EventEmitter, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RollsSubmitted } from '../../data/events/rolls-submitted';

@Component({
  selector: 'app-round-rolls',
  templateUrl: './round-rolls.component.html',
  styleUrls: ['./round-rolls.component.css']
})
export class RoundRollsComponent implements OnChanges {
  @Input() gameFinished: boolean;
  @Output() submitRolls: EventEmitter<RollsSubmitted> = new EventEmitter<RollsSubmitted>();
  @Output() resetGame: EventEmitter<any> = new EventEmitter<any>();
  addressForm = this.fb.group({
    firstRoll: [null],
    secondRoll: [null],
  });

  constructor(private fb: FormBuilder) {}

  ngOnChanges(changes: SimpleChanges): void {
    if(this.gameFinished) {
      this.addressForm.reset();
      this.addressForm.disable();
    }else{
      this.addressForm.enable();
    }
  }

  submit() {
    let firstRoll = this.addressForm.get('firstRoll').value;
    let secondRoll = this.addressForm.get('secondRoll').value == null ? 0 : this.addressForm.get('secondRoll').value
    this.submitRolls.emit(<RollsSubmitted> {
      firstRoll: firstRoll,
      secondRoll: secondRoll
    })
  }

  playAgain() {
    this.resetGame.emit(null);
  }
}
