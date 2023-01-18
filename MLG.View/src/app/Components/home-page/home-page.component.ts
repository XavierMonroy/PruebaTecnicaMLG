import { ArticleInterface } from './../../Interface/ArticleInterface';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.sass']
})
export class HomePageComponent implements OnInit {

  articles: ArticleInterface[] = [];

  articlesLocalStorage: any[] = [];

  constructor() { }

  ngOnInit(): void {
    this.articles.push({
      pkArticle: 1,
      articleName: 'Celular',
      code: '15648',
      description: 'dasdfgdfg',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 2,
      articleName: 'Computadora',
      code: '15648',
      description: 'tes tes tse',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 3,
      articleName: 'Laptop',
      code: '1894654',
      description: 'loremfs fsdf sdf sdf sdf ',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 4,
      articleName: 'Sillón',
      code: '8486151',
      description: 'fsdfsdf sdf sdf sdf sdf sdf',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 5,
      articleName: 'Teclado',
      code: '86146785',
      description: 'fsdf sdf jghj ettfdgg ',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 6,
      articleName: 'Mouse',
      code: '894318',
      description: 'gdfh hdfgsr dgfdg bvcrtert',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 7,
      code: '15648',
      articleName: 'Lampara',
      description: 'uuyt hfghert dfghfh fgh',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 8,
      code: '15648',
      articleName: 'Puertas',
      description: 'dfg jtyu wer vgh fg ',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 9,
      code: '15648',
      articleName: 'Tacos',
      description: 'htyu hfgh dsgfgsfd',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });
    this.articles.push({
      pkArticle: 10,
      code: '15648',
      articleName: 'Balón',
      description: 'hfg hfgh fghertet ',
      price: 50,
      image: '',
      stock: 50,
      IsAvailable: true,
      LastUpdated: new Date()
    });

    this.articlesLocalStorage = JSON.parse(localStorage.getItem('cartMLG') + '') || [];

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


