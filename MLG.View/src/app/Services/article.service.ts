import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
//import { AccountService } from './account.service';
import { urlAPI } from '../app.constants';
import { ArticleInterface } from '../Interface/ArticleInterface';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class ArticleService{
    constructor(
        private http: HttpClient//, 
        //private accountService: AccountService
    ) { }

    getAllArticlesByStore(): Observable<ArticleInterface[]>{
        return this.http.get<ArticleInterface[]>(urlAPI + 'articles/GetAllArticles');    
    }
}