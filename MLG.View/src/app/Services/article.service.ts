import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
//import { AccountService } from './account.service';
import { urlAPI } from '../app.constants';
import { ArticleInterface } from '../Interface/ArticleInterface';

@Injectable({
  providedIn: 'root'
})

export class ArticleService{
    constructor(
        private http: HttpClient//, 
        //private accountService: AccountService
    ) { }

    getAllArticlesByStore(FKStore : number): Observable<ArticleInterface[]>{
        return this.http.get<ArticleInterface[]>(urlAPI + 'articles/GetAllArticlesByStore/' + FKStore);    
    }
}