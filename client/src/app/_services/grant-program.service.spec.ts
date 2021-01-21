import { TestBed } from '@angular/core/testing';

import { GrantProgramService } from './grant-program.service';

describe('GrantProgramService', () => {
  let service: GrantProgramService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GrantProgramService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
