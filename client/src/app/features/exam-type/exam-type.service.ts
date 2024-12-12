import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ExamType } from '../../core/models/ExamType';

@Injectable({
  providedIn: 'root',
})
export class ExamTypeService {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/ExamType`;

  getExamTypes(): Observable<ExamType[]> {
    return this.http.get<ExamType[]>(this.apiUrl);
  }

  getExamTypeById(id: number): Observable<ExamType> {
    return this.http.get<ExamType>(`${this.apiUrl}/${id}`);
  }

  createExamType(examType: Partial<ExamType>): Observable<ExamType> {
    return this.http.post<ExamType>(this.apiUrl, examType);
  }

  updateExamType(examType: Partial<ExamType>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${examType.id}`, examType);
  }

  deleteExamType(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
