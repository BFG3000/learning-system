import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Login } from '../../app/core/models/Login';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loginUrl = `${environment.apiUrl}/Auth/login`; // Update this to match your API endpoint
  private http = inject(HttpClient);
  private router = inject(Router);
  private isAuthenticated = new BehaviorSubject<boolean>(this.hasToken());
  private tokenKey = 'auth_token';

  login(credentials: { username: string; password: string }): Observable<void> {
    return this.http.post<{ token: string }>(this.loginUrl, credentials).pipe(
      map((response) => {
        localStorage.setItem(this.tokenKey, response.token); // Store the token securely
        this.isAuthenticated.next(true); // Notify subscribers
      })
    );
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey); // Clear the token on logout
    this.router.navigate(['/login']);
  }

  setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token); // Store the token in localStorage
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey); // Retrieve the token from localStorage
  }

  isLoggedIn(): Observable<boolean> {
    return this.isAuthenticated.asObservable();
  }

  private hasToken(): boolean {
    return !!localStorage.getItem('auth_token');
  }

  isTokenExpired(): boolean {
    const token = this.getToken();
    if (!token) return true;

    const payload = JSON.parse(atob(token.split('.')[1]));
    const expirationDate = payload.exp * 1000; // Expiration date in milliseconds
    return Date.now() > expirationDate;
  }
}
