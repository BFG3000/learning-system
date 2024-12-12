import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamVariantFormComponent } from './exam-variant-form.component';

describe('ExamVariantFormComponent', () => {
  let component: ExamVariantFormComponent;
  let fixture: ComponentFixture<ExamVariantFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExamVariantFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamVariantFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
