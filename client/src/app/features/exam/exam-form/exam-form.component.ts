import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ExamService } from '../exam.service';
import { Exam } from '../../../core/models/Exam';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-exam-form',
  templateUrl: './exam-form.component.html',
  styleUrls: ['./exam-form.component.scss'],
  imports: [CommonModule,ReactiveFormsModule],
  standalone: true,
  
})
export class ExamFormComponent {
  examForm: FormGroup;
  isEditMode = false;
  private examService = inject(ExamService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.examForm = this.fb.group({
      name: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      locationId: [null, Validators.required],
    });

    const examId = this.route.snapshot.paramMap.get('id');
    if (examId) {
      this.isEditMode = true;
      this.examService.getExamById(+examId).subscribe((exam: Exam) => {
        this.examForm.patchValue(exam);
      });
    }
  }

  onSubmit(): void {
    if (this.examForm.invalid) return;

    const formData = this.examForm.value;
    if (this.isEditMode) {
      this.examService.updateExam(formData).subscribe(() => {
        alert('Exam updated successfully');
        this.router.navigate(['/exam']);
      });
    } else {
      this.examService.createExam(formData).subscribe(() => {
        alert('Exam created successfully');
        this.router.navigate(['/exam']);
      });
    }
  }
}
