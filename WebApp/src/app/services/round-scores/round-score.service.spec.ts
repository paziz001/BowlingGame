import { TestBed } from '@angular/core/testing';

import { RoundScoreService } from './round-score.service';

describe('RoundScoresService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  xit('should be created', () => {
    const service: RoundScoreService = TestBed.get(RoundScoreService);
    expect(service).toBeTruthy();
  });
});
