import { TestBed } from '@angular/core/testing';

import { ApplicantdetailsService } from './applicantdetails.service';

describe('ApplicantdetailsService', () => {
  let service: ApplicantdetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplicantdetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
