import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';

import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Router } from '@angular/router';


export const httpErrorInterceptor: HttpInterceptorFn = (req, next) => {
  let router = inject(Router);
  return next(req).pipe(
    catchError((error) => {
      if (error.status === 401 || error.status === 403) {
        // Redirect to login on unauthorized access
        router.navigate(['/login']);
      }
      return throwError(() => error);
    })
  );
};

