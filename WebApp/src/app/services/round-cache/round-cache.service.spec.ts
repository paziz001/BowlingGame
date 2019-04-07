import { TestBed } from '@angular/core/testing';

import { RoundCacheService } from './round-cache.service';

describe('RoundCacheService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RoundCacheService = TestBed.get(RoundCacheService);
    expect(service).toBeTruthy();
  });
});
