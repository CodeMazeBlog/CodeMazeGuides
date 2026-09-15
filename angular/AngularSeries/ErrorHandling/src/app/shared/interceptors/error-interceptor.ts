import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { EMPTY, catchError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);

  const createErrorMessage = (error: HttpErrorResponse): string =>
    error.error ? error.error : error.statusText;

  const handle500Error = () => {
    router.navigate(['/500']);
  };

  const handle404Error = () => {
    router.navigate(['/404']);
  };

  const handleOtherError = (error: HttpErrorResponse) => {
    createErrorMessage(error); // this will be fixed later
  };

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 500) {
        handle500Error();
      }
      else if (error.status === 404) {
        handle404Error();
      }
      else {
        handleOtherError(error);
      }

      return EMPTY;
    })
  );
};
