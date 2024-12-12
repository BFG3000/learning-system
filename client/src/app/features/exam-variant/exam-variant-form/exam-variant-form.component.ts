import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ExamVariantService } from '../exam-variant.service';
import { ExamQuestionService } from '../../exam-question/exam-question.service';
import { ExamDefinitionService } from '../../exam-definition/exam-definition.service';
import { ExamVariant } from '../../../core/models/ExamVariant';
import { ExamDefinition } from '../../../core/models/ExamDefinition';
import { ExamQuestion } from '../../../core/models/ExamQuestion';

@Component({
  selector: 'app-exam-variant-form',
  templateUrl: './exam-variant-form.component.html',
  styleUrls: ['./exam-variant-form.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule], // Import Reactive Forms
})
export class ExamVariantFormComponent {
  examVariantForm: FormGroup;
  isEditMode = false;
  examDefinitions: ExamDefinition[] = [];
  examQuestions: ExamQuestion[] = [];

  private examVariantService = inject(ExamVariantService);
  private examQuestionService = inject(ExamQuestionService);
  private examDefinitionService = inject(ExamDefinitionService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.examVariantForm = this.fb.group({
      name: ['', Validators.required],
      examDefinitionId: ['', Validators.required],
      examQuestions: [[], Validators.required],
    });

    this.examDefinitionService.getExamDefinitions().subscribe((data) => {
      this.examDefinitions = data;
    });

    this.examQuestionService.getExamQuestions().subscribe((data) => {
      this.examQuestions = data;
    });

    const examVariantId = this.route.snapshot.paramMap.get('id');
    if (examVariantId) {
      this.isEditMode = true;
      this.examVariantService.getExamVariantById(+examVariantId).subscribe((examVariant: ExamVariant) => {
        this.examVariantForm.patchValue(examVariant);
      });
    }
  }

  onSubmit(): void {
    if (this.examVariantForm.invalid) return;

    const formData = this.examVariantForm.value;
    if (this.isEditMode) {
      this.examVariantService.updateExamVariant(formData).subscribe(() => {
        alert('Exam Variant updated successfully');
        this.router.navigate(['/exam-variant']);
      });
    } else {
      this.examVariantService.createExamVariant(formData).subscribe(() => {
        alert('Exam Variant created successfully');
        this.router.navigate(['/exam-variant']);
      });
    }
  }
}
