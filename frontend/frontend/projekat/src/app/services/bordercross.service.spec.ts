import { TestBed } from '@angular/core/testing';

import { BordercrossService } from './bordercross.service';

describe('BordercrossService', () => {
  let service: BordercrossService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BordercrossService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
