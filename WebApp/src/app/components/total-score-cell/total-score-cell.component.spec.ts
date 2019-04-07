import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalScoreCellComponent } from './total-score-cell.component';

describe('TotalScoreCellComponent', () => {
  let component: TotalScoreCellComponent;
  let fixture: ComponentFixture<TotalScoreCellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalScoreCellComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalScoreCellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
