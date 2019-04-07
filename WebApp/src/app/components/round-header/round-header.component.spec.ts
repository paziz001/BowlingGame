import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundHeaderComponent } from './round-header.component';

describe('RoundHeaderComponent', () => {
  let component: RoundHeaderComponent;
  let fixture: ComponentFixture<RoundHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoundHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoundHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
