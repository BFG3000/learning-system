import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExamDefinition } from '../../core/models/ExamDefinition';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ExamDefinitionService {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/ExamDefinition`;

  getExamDefinitions(): Observable<ExamDefinition[]> {
    return this.http.get<ExamDefinition[]>(this.apiUrl);
  }

  getExamDefinitionById(id: number): Observable<ExamDefinition> {
    return this.http.get<ExamDefinition>(`${this.apiUrl}/${id}`);
  }

  createExamDefinition(examDefinition: Partial<ExamDefinition>): Observable<ExamDefinition> {
    return this.http.post<ExamDefinition>(this.apiUrl, examDefinition);
  }

  updateExamDefinition(examDefinition: Partial<ExamDefinition>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${examDefinition.id}`, examDefinition);
  }

  deleteExamDefinition(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
