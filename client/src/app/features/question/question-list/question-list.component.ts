import { Component, inject } from '@angular/core';
import { QuestionService } from '../question.service';
import { Question } from '../../../core/models/Question';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  imports: [RouterLink,CommonModule],
  styleUrls: ['./question-list.component.scss'],
  standalone: true,
})
export class QuestionListComponent {
  questions: Question[] = [];
  private questionService = inject(QuestionService);

  constructor() {
    this.questionService.getQuestions().subscribe((data) => (this.questions = data));
  }
}
