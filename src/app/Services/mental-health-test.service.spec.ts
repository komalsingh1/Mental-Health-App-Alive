import { TestBed } from '@angular/core/testing';

import { MentalHealthTestService } from './mental-health-test.service';

describe('MentalHealthTestService', () => {
  let service: MentalHealthTestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MentalHealthTestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
