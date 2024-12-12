import { Component, inject } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ExamVariantService } from '../exam-variant.service';
import { ExamVariant } from '../../../core/models/ExamVariant';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-exam-variant-detail',
  templateUrl: './exam-variant-detail.component.html',
  imports: [RouterLink,CommonModule],
  styleUrls: ['./exam-variant-detail.component.scss'],
  standalone: true,
})
export class ExamVariantDetailComponent {
  examVariant: ExamVariant | null = null;
  private examVariantService = inject(ExamVariantService);
  private route = inject(ActivatedRoute);

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.examVariantService.getExamVariantById(id).subscribe((data) => {
      this.examVariant = data;
    });
  }
}
