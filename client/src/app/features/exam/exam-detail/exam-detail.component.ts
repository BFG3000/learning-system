import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExamService } from '../exam.service';
import { Exam } from '../../../core/models/Exam';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-exam-detail',
  templateUrl: './exam-detail.component.html',
  styleUrls: ['./exam-detail.component.scss'],
  imports: [CommonModule],
  standalone: true,
})
export class ExamDetailComponent {
  exam: Exam | null = null;
  private route = inject(ActivatedRoute);
  private examService = inject(ExamService);

  constructor() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.examService.getExamById(id).subscribe((data) => (this.exam = data));
  }
}
