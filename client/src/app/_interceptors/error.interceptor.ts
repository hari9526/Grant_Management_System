import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { errorMonitor } from 'events';
import { ToastrService } from 'ngx-toastr';
import { NavigationExtras, Router } from '@angular/router';
import { SpinnerService } from '../_services/spinner.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService, private router: Router, private spinner: SpinnerService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    
    return this.handler(next, request);

  }
  handler(next, request) {
    this.spinner.requestStarted();
    return next.handle(request).pipe(
      
      map((event: HttpEvent<any>) => {
       
        if (event instanceof HttpResponse) {
          this.spinner.requestEnded();
        }
        return event;
      }),

      catchError(error => {
        
        if (error) {
          this.spinner.resetSpinner();
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
                this.toastr.error(error.error, "Oops!");
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
