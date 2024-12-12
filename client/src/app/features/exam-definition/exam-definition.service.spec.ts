import { TestBed } from '@angular/core/testing';

import { ExamDefinitionService } from './exam-definition.service';

describe('ExamDefinitionService', () => {
  let service: ExamDefinitionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamDefinitionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
