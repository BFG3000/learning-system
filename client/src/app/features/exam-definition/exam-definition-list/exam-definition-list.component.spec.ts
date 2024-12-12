import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamDefinitionListComponent } from './exam-definition-list.component';

describe('ExamDefinitionListComponent', () => {
  let component: ExamDefinitionListComponent;
  let fixture: ComponentFixture<ExamDefinitionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExamDefinitionListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamDefinitionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
