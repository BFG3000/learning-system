import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResultService } from '../result.service';
import { Result } from '../../../core/models/Result';

@Component({
  selector: 'app-result-form',
  templateUrl: './result-form.component.html',
  styleUrls: ['./result-form.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule], // Import necessary modules
})
export class ResultFormComponent {
  resultForm: FormGroup;
  isEditMode = false;
  private resultService = inject(ResultService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.resultForm = this.fb.group({
      score: [null, [Validators.required, Validators.min(0)]],
      userExamId: ['', Validators.required],
    });

    const resultId = this.route.snapshot.paramMap.get('id');
    if (resultId) {
      this.isEditMode = true;
      this.resultService.getResultById(+resultId).subscribe((result: Result) => {
        this.resultForm.patchValue(result);
      });
    }
  }

  onSubmit(): void {
    if (this.resultForm.invalid) return;

    const formData = this.resultForm.value;
    if (this.isEditMode) {
      this.resultService.updateResult(formData).subscribe(() => {
        alert('Result updated successfully');
        this.router.navigate(['/result']);
      });
    } else {
      this.resultService.createResult(formData).subscribe(() => {
        alert('Result created successfully');
        this.router.navigate(['/result']);
      });
    }
  }
}
