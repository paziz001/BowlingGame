import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundScoreCellComponent } from './round-score-cell.component';

describe('RoundScoreCellComponent', () => {
  let component: RoundScoreCellComponent;
  let fixture: ComponentFixture<RoundScoreCellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoundScoreCellComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoundScoreCellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
