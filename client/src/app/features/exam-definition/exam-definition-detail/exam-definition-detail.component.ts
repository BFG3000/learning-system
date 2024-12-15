import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ExamDefinitionService } from '../exam-definition.service';
import { ExamService } from '../../exam/exam.service';
import { ExamVariantService } from '../../exam-variant/exam-variant.service';
import { ExamDefinition } from '../../../core/models/ExamDefinition';
import { Exam } from '../../../core/models/Exam';
import { ExamVariant } from '../../../core/models/ExamVariant';
import { CommonModule } from '@angular/common';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbar } from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-exam-definition-detail',
  templateUrl: './exam-definition-detail.component.html',
  imports: [
    RouterLink,
    CommonModule,
    MatToolbar,
    MatTable,
    MatTableModule,
  
    MatCardModule,
    MatButtonModule,
  ],
  styleUrls: ['./exam-definition-detail.component.scss'],
  standalone: true,
})
export class ExamDefinitionDetailComponent {
  examDefinition: ExamDefinition | null = null;

  private examDefinitionService = inject(ExamDefinitionService);
  private examService = inject(ExamService);
  private examVariantService = inject(ExamVariantService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.examDefinitionService.getExamDefinitionById(id).subscribe((data) => {
      console.log('data: ',data);
      this.examDefinition = data;
    });

    // this.examService.getExamsByDefinitionId(id).subscribe((data) => {
    //   this.exams = data;
    // });

    // this.examVariantService.getExamVariantsByDefinitionId(id).subscribe((data) => {
    //   this.examVariants = data;
    // });
  }

  createExam(): void {
    this.router.navigate(['/exam/form'], {
      queryParams: { examDefinitionId: this.examDefinition?.id },
    });
  }

  editExam(examId: number): void {
    this.router.navigate(['/exam/form', { id: examId }]);
  }

  createExamVariant(): void {
    this.router.navigate(['/exam-variant/form'], {
      queryParams: { examDefinitionId: this.examDefinition?.id },
    });
  }

  editExamVariant(variantId: number): void {
    this.router.navigate(['/exam-variant/form', { id: variantId }]);
  }
}
