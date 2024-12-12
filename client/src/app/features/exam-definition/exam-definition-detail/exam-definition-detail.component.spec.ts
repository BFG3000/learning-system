import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamDefinitionDetailComponent } from './exam-definition-detail.component';

describe('ExamDefinitionDetailComponent', () => {
  let component: ExamDefinitionDetailComponent;
  let fixture: ComponentFixture<ExamDefinitionDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExamDefinitionDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamDefinitionDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
