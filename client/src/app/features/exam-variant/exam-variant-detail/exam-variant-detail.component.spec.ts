import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamVariantDetailComponent } from './exam-variant-detail.component';

describe('ExamVariantDetailComponent', () => {
  let component: ExamVariantDetailComponent;
  let fixture: ComponentFixture<ExamVariantDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExamVariantDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamVariantDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
