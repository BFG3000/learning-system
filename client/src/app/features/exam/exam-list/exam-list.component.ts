import { Component, inject } from '@angular/core';
import { ExamService } from '../exam.service';
import { Exam } from '../../../core/models/Exam';
import { LoadingService } from '../../../core/loading/loading.service'; 
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { LoadingComponent } from "../../../shared/loading/loading.component";

@Component({
  selector: 'app-exam-list',
  templateUrl: './exam-list.component.html',
  imports: [RouterLink, CommonModule, LoadingComponent],
  styleUrls: ['./exam-list.component.scss'],
  standalone: true,
})
export class ExamListComponent {
  private loadingService = inject(LoadingService);
  private examService = inject(ExamService);

  exams: Exam[] = [];
  loading = this.loadingService.loading;  


  constructor() {
    this.examService.getExams().subscribe((data) => (this.exams = data));
  }
}
