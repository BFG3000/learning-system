import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ExamQuestionService } from '../exam-question.service';
import { ExamQuestion } from '../../../core/models/ExamQuestion';

@Component({
  selector: 'app-exam-question-form',
  templateUrl: './exam-question-form.component.html',
  styleUrls: ['./exam-question-form.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule], // Import Reactive Forms
})
export class ExamQuestionFormComponent {
  examQuestionForm: FormGroup;
  isEditMode = false;
  private examQuestionService = inject(ExamQuestionService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.examQuestionForm = this.fb.group({
      questionText: ['', Validators.required],
    });

    const questionId = this.route.snapshot.paramMap.get('id');
    if (questionId) {
      this.isEditMode = true;
      this.examQuestionService.getExamQuestionById(+questionId).subscribe((question: ExamQuestion) => {
        this.examQuestionForm.patchValue(question);
      });
    }
  }

  onSubmit(): void {
    if (this.examQuestionForm.invalid) return;

    const formData = this.examQuestionForm.value;
    if (this.isEditMode) {
      this.examQuestionService.updateExamQuestion(formData).subscribe(() => {
        alert('Exam Question updated successfully');
        this.router.navigate(['/exam-question']);
      });
    } else {
      this.examQuestionService.createExamQuestion(formData).subscribe(() => {
        alert('Exam Question created successfully');
        this.router.navigate(['/exam-question']);
      });
    }
  }
}
