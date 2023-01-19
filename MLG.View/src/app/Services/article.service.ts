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

    updateArticle(article: ArticleInterface): Observable<any> {    
        const model = {
          PKArticle: article.pkArticle,
          ArticleName: article.articleName,
          Code: article.code,
          Description: article.description,
          Price: article.price,
          Image: article.image,
          Stock: article.stock,
          IsAvailable: article.isAvailable
        }
    
        return this.http.put(urlAPI + 'articles/UpdateArticle', model);
    }

    createArticle(article: ArticleInterface): Observable<any> {   
        const model = {
            ArticleName: article.articleName,
            Code: article.code,
            Description: article.description,
            Price: article.price,
            Image: article.image,
            Stock: article.stock,
            IsAvailable: article.isAvailable
        }
    
        return this.http.post(urlAPI + 'articles/CreateArticle', model);
    }
}