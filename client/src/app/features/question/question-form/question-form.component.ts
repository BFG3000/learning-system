import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionService } from '../question.service';
import { Question } from '../../../core/models/Question';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule], // Import reactive forms module
})
export class QuestionFormComponent {
  questionForm: FormGroup;
  isEditMode = false;
  private questionService = inject(QuestionService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.questionForm = this.fb.group({
      name: ['', Validators.required],
      marks: ['', [Validators.required, Validators.min(1)]],
    });

    const questionId = this.route.snapshot.paramMap.get('id');
    if (questionId) {
      this.isEditMode = true;
      this.questionService.getQuestionById(+questionId).subscribe((question: Question) => {
        this.questionForm.patchValue(question);
      });
    }
  }

  onSubmit(): void {
    if (this.questionForm.invalid) return;

    const formData = this.questionForm.value;
    if (this.isEditMode) {
      this.questionService.updateQuestion(formData).subscribe(() => {
        alert('Question updated successfully');
        this.router.navigate(['/question']);
      });
    } else {
      this.questionService.createQuestion(formData).subscribe(() => {
        alert('Question created successfully');
        this.router.navigate(['/question']);
      });
    }
  }
}
