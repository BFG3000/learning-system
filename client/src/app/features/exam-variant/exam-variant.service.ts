import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExamVariant } from '../../core/models/ExamVariant';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ExamVariantService {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/ExamVariant`;

  getExamVariants(): Observable<ExamVariant[]> {
    return this.http.get<ExamVariant[]>(this.apiUrl);
  }

  getExamVariantById(id: number): Observable<ExamVariant> {
    return this.http.get<ExamVariant>(`${this.apiUrl}/${id}`);
  }

  createExamVariant(examVariant: Partial<ExamVariant>): Observable<ExamVariant> {
    return this.http.post<ExamVariant>(this.apiUrl, examVariant);
  }

  updateExamVariant(examVariant: Partial<ExamVariant>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${examVariant.id}`, examVariant);
  }

  deleteExamVariant(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
