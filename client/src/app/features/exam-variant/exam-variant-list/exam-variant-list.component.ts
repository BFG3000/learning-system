import { Component, inject } from '@angular/core';
import { ExamVariantService } from '../exam-variant.service';
import { ExamVariant } from '../../../core/models/ExamVariant';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-exam-variant-list',
  templateUrl: './exam-variant-list.component.html',
  styleUrls: ['./exam-variant-list.component.scss'],
  imports: [RouterLink,CommonModule],
  standalone: true,
})
export class ExamVariantListComponent {
  examVariants: ExamVariant[] = [];
  private examVariantService = inject(ExamVariantService);

  ngOnInit(): void {
    this.examVariantService.getExamVariants().subscribe((data) => {
      this.examVariants = data;
    });
  }
}
