import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';
//import { AccountService } from '../services/account.service';

@Injectable()
export class HeaderInterceptor implements HttpInterceptor {
  constructor(
    //private accountService: AccountService
  ) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    //const headers = this.accountService.getHeadersWithToken();
    return next.handle(request.clone({ headers: new HttpHeaders({'Access-Control-Allow-Origin' : '*'})  }));
  }
}
