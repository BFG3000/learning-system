import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExamQuestion } from '../../core/models/ExamQuestion';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ExamQuestionService {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/ExamQuestion`;

  getExamQuestions(): Observable<ExamQuestion[]> {
    return this.http.get<ExamQuestion[]>(this.apiUrl);
  }

  getExamQuestionById(id: number): Observable<ExamQuestion> {
    return this.http.get<ExamQuestion>(`${this.apiUrl}/${id}`);
  }

  createExamQuestion(examQuestion: Partial<ExamQuestion>): Observable<ExamQuestion> {
    return this.http.post<ExamQuestion>(this.apiUrl, examQuestion);
  }

  updateExamQuestion(examQuestion: Partial<ExamQuestion>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${examQuestion.id}`, examQuestion);
  }

  deleteExamQuestion(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
