import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { errorMonitor } from 'events';
import { ToastrService } from 'ngx-toastr';
import { Console } from 'console';
import { NavigationExtras, Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService, private router: Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          switch (error.status) {
            case 400:
              if (error.error.errors) {
                const modalStateErrors = [];
                for (const key in error.error.errors) {
                  if (error.error.errors[key]) {
                    modalStateErrors.push(error.error.errors[key]);
                  }
                }
                throw modalStateErrors.flat();
              }
              else {
                this.toastr.error(error.error, "Holy Cow!");
                console.log(error.error);
              }
              break;
            case 401:
              this.toastr.error(error.error, "Authorization Failed!");
              console.log(error);
              break;
            case 404:
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              const navigationExtra: NavigationExtras = { state: { error: error.error } }
              this.router.navigateByUrl('/server-error', navigationExtra);
              break;
            default:
              this.toastr.error("Something went wrong!");
              console.log(error);
              break;
          }
        }
        return throwError(error);
      })
    );
  }
}
