import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Login } from '../../app/core/models/Login';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = `${environment.apiUrl}/Auth`;
  private tokenKey = 'auth_token';

  constructor(private http: HttpClient, private router: Router) {}

  login(credentials: Login): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, credentials);
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

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token; // Check if there’s a valid token
  }

  isTokenExpired(): boolean {
    const token = this.getToken();
    if (!token) return true;

    const payload = JSON.parse(atob(token.split('.')[1]));
    const expirationDate = payload.exp * 1000; // Expiration date in milliseconds
    return Date.now() > expirationDate;
  }
}
