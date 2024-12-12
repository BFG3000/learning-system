import { TestBed } from '@angular/core/testing';

import { ExamVariantService } from './exam-variant.service';

describe('ExamVariantService', () => {
  let service: ExamVariantService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamVariantService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
