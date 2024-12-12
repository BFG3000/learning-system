import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../../core/models/Result';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ResultService {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/Result`;

  getResults(): Observable<Result[]> {
    return this.http.get<Result[]>(this.apiUrl);
  }

  getResultById(id: number): Observable<Result> {
    return this.http.get<Result>(`${this.apiUrl}/${id}`);
  }

  createResult(result: Partial<Result>): Observable<Result> {
    return this.http.post<Result>(this.apiUrl, result);
  }

  updateResult(result: Partial<Result>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${result.id}`, result);
  }

  deleteResult(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
