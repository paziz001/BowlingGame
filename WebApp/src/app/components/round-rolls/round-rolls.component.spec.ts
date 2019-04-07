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

import { RoundRollsComponent } from './round-rolls.component';

describe('RoundRollsComponent', () => {
  let component: RoundRollsComponent;
  let fixture: ComponentFixture<RoundRollsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoundRollsComponent ],
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
    fixture = TestBed.createComponent(RoundRollsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should compile', () => {
    expect(component).toBeTruthy();
  });
});
