import { ArticleInterface } from './../../Interface/ArticleInterface';
import { ArticleService } from 'src/app/services/article.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.sass'],
})
export class HomePageComponent implements OnInit {

  articles: ArticleInterface[] = [];
  articlesLocalStorage: any[] = [];

  constructor(
    private articleService: ArticleService
  ) { }

  ngOnInit(): void {
    this.readArticles();
    this.articlesLocalStorage = JSON.parse(localStorage.getItem('cartMLG') + '') || [];
  }

  readArticles(){
    this.articleService.getAllArticlesByStore(1).subscribe((response) =>{
      if (response.length > 0) {
        this.articles = [];
        this.articles = response;
      }
    });
  }

  fnloadLocalStorage() {

  }

  fnAddArticleinLocalStorage(model: any) {
    const exits = this.articlesLocalStorage.some(element => element.pkArticle === model.pkArticle);
    if(!model.count || !exits) model.count = 1;

    if (exits) {
      const article = this.articlesLocalStorage.map(element => {
        if (element.pkArticle === model.pkArticle) {
          element.count++;
          return element; 
        } else {
          return element; 
        }
      });
      this.articlesLocalStorage = [...article];
    } else {
      this.articlesLocalStorage = [...this.articlesLocalStorage, model];
    }
  }

  fnDeleteArticle(pkArticle: number) {
    this.articlesLocalStorage = this.articlesLocalStorage.filter(element => element.pkArticle !== pkArticle );
    // Mandar el this.articlesLocalStorage a LocalStorage
  }

  fnDeleteCart() {
    this.articlesLocalStorage = [];
    // Mandar el this.articlesLocalStorage a LocalStorage
  }

}


