import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamDefinitionCompleteFormComponent } from './exam-definition-complete-form.component';

describe('ExamDefinitionCompleteFormComponent', () => {
  let component: ExamDefinitionCompleteFormComponent;
  let fixture: ComponentFixture<ExamDefinitionCompleteFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExamDefinitionCompleteFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamDefinitionCompleteFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
