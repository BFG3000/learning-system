import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamVariantListComponent } from './exam-variant-list.component';

describe('ExamVariantListComponent', () => {
  let component: ExamVariantListComponent;
  let fixture: ComponentFixture<ExamVariantListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExamVariantListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamVariantListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
