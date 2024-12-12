import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamDefinitionFormComponent } from './exam-definition-form.component';

describe('ExamDefinitionFormComponent', () => {
  let component: ExamDefinitionFormComponent;
  let fixture: ComponentFixture<ExamDefinitionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExamDefinitionFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamDefinitionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
