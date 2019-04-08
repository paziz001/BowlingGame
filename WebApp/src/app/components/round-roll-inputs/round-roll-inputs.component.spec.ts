import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatButtonModule,
  MatCardModule,
  MatInputModule,
  MatRadioModule,
  MatSelectModule,
} from '@angular/material';

import { RoundRollInputsComponent } from './round-roll-inputs.component';

describe('RoundRollsComponent', () => {
  let component: RoundRollInputsComponent;
  let fixture: ComponentFixture<RoundRollInputsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoundRollInputsComponent ],
      imports: [
        NoopAnimationsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatCardModule,
        MatInputModule,
        MatRadioModule,
        MatSelectModule,
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoundRollInputsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should compile', () => {
    expect(component).toBeTruthy();
  });
});
