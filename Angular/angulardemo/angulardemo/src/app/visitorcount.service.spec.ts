import { TestBed } from '@angular/core/testing';

import { VisitorcountService } from './visitorcount.service';

describe('VisitorcountService', () => {
  let service: VisitorcountService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VisitorcountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
