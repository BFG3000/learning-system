import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { ExamQuestion } from '../../../core/models/ExamQuestion';
import { ExamQuestionService } from '../exam-question.service';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-exam-question-list',
  imports: [RouterLink,CommonModule],
  templateUrl: './exam-question-list.component.html',
  styleUrl: './exam-question-list.component.scss'
})
export class ExamQuestionListComponent {
  examQuestionList : ExamQuestion[] =[];
  private examQuestionService = inject(ExamQuestionService);

  ngOnInit():void{
    this.examQuestionService.getExamQuestions().subscribe(
      (data)=>{
        this.examQuestionList = this.examQuestionList;
      }
    )
  }
}
