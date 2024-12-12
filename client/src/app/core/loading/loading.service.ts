import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  private loadingSubject = new BehaviorSubject<boolean>(false);
  loading = this.loadingSubject.asObservable(); // Observable to subscribe to loading state

  // Start loading
  startLoading(): void {
    this.loadingSubject.next(true);
  }

  // Stop loading
  stopLoading(): void {
    this.loadingSubject.next(false);
  }
}
