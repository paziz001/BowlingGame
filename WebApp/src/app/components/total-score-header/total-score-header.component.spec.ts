import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalScoreHeaderComponent } from './total-score-header.component';

describe('TotalScoreHeaderComponent', () => {
  let component: TotalScoreHeaderComponent;
  let fixture: ComponentFixture<TotalScoreHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalScoreHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalScoreHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
