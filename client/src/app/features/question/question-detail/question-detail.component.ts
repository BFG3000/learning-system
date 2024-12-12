import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionService } from '../question.service';
import { Question } from '../../../core/models/Question';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-question-detail',
  templateUrl: './question-detail.component.html',
  imports:[CommonModule],
  styleUrls: ['./question-detail.component.scss'],
  standalone: true,
})
export class QuestionDetailComponent {
  question: Question | null = null;
  private route = inject(ActivatedRoute);
  private questionService = inject(QuestionService);

  constructor() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.questionService.getQuestionById(id).subscribe((data) => (this.question = data));
  }
}
