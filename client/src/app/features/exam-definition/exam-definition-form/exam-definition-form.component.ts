import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ExamDefinitionService } from '../exam-definition.service';
import { ExamTypeService } from '../../exam-type/exam-type.service';
import { CategoryService } from '../../category/category.service';
import { ExamDefinition } from '../../../core/models/ExamDefinition';
import { ExamType } from '../../../core/models/ExamType';
import { Category } from '../../../core/models/Category';

@Component({
  selector: 'app-exam-definition-form',
  templateUrl: './exam-definition-form.component.html',
  styleUrls: ['./exam-definition-form.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule], // Import Reactive Forms
})
export class ExamDefinitionFormComponent {
  examDefinitionForm: FormGroup;
  examTypes: ExamType[] = [];
  categories: Category[] = [];
  isEditMode = false;
  private examDefinitionService = inject(ExamDefinitionService);
  private examTypeService = inject(ExamTypeService);
  private categoryService = inject(CategoryService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.examDefinitionForm = this.fb.group({
      name: ['', Validators.required],
      categoryId: [null, Validators.required],
      duration: [0, [Validators.required, Validators.min(1)]],
      examTypeId: [null, Validators.required],
    });

    this.examTypeService.getExamTypes().subscribe((data) => {
      this.examTypes = data;
    });

    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;
    });

    const examDefinitionId = this.route.snapshot.paramMap.get('id');
    if (examDefinitionId) {
      this.isEditMode = true;
      this.examDefinitionService.getExamDefinitionById(+examDefinitionId).subscribe((examDefinition: ExamDefinition) => {
        this.examDefinitionForm.patchValue(examDefinition);
      });
    }
  }

  onSubmit(): void {
    if (this.examDefinitionForm.invalid) return;

    const formData = this.examDefinitionForm.value;
    if (this.isEditMode) {
      this.examDefinitionService.updateExamDefinition(formData).subscribe(() => {
        alert('Exam Definition updated successfully');
        this.router.navigate(['/exam-definition']);
      });
    } else {
      this.examDefinitionService.createExamDefinition(formData).subscribe(() => {
        alert('Exam Definition created successfully');
        this.router.navigate(['/exam-definition']);
      });
    }
  }
}
