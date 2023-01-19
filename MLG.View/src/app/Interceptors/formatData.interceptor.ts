import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, filter, map } from 'rxjs/operators';
import { Event, Router } from '@angular/router';

@Injectable()
export class FormatDataInterceptor implements HttpInterceptor {
  constructor(
    private _router: Router
  ) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      filter((event : any) => event instanceof HttpResponse),
      map((event: HttpResponse<any>) => event.clone({ body: event.body.data }))
    );
  }
}
