import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { finalize, Observable } from 'rxjs';
import { Exam } from '../../core/models/Exam';
import { LoadingService } from '../../core/loading/loading.service';  // Import the loading service
import { environment } from '../../../environments/environment'; // Import environment


@Injectable({
  providedIn: 'root',
})
export class ExamService {
  private http = inject(HttpClient);
  private loadingService = inject(LoadingService);
  private apiUrl = `${environment.apiUrl}/Exam`;

  getExams(): Observable<Exam[]> {
    this.loadingService.startLoading();
    return this.http.get<Exam[]>(this.apiUrl).pipe(
      finalize(() => this.loadingService.stopLoading())
    );
  }

  getExamById(id: number): Observable<Exam> {
    this.loadingService.startLoading();
    return this.http.get<Exam>(`${this.apiUrl}/${id}`).pipe(
      finalize(() => this.loadingService.stopLoading())
    );

  }

  createExam(exam: Partial<Exam>): Observable<Exam> {
    this.loadingService.startLoading();
    return this.http.post<Exam>(this.apiUrl, exam).pipe(
      finalize(() => this.loadingService.stopLoading())
    );

  }

  updateExam(exam: Partial<Exam>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${exam.id}`, exam).pipe(
      finalize(() => this.loadingService.stopLoading())
    );

  }
}
