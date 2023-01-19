import { Component, OnInit } from '@angular/core';
import { ArticleInterface } from 'src/app/Interface/ArticleInterface';
import { TableSchema } from 'src/app/Interface/TableSchema';
import { Table } from 'primeng/table';
import { ArticleService } from 'src/app/Services/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.sass']
})
export class ArticlesComponent implements OnInit {
  articles: ArticleInterface[] = [];
  popUp: boolean = false;
  loading: boolean = true;
  submitted: boolean = false;
  totalRecords: number = 0;
  columns: TableSchema[] = [];
  clonedArticle: ArticleInterface = {} as ArticleInterface;

  constructor(
    private articleService: ArticleService,
    //private messageService: MessageService,
  ) { }

  ngOnInit(): void {
    this.readArticles(); 
  }

  readArticles() {
    this.articleService.getAllArticlesByStore().subscribe((response) => {
      if (response.length > 0) {
        this.articles = [];
        this.columns = [];
        this.articles = response;
        this.totalRecords = response.length;
        Object.keys(response[0]).filter(u => u.toLowerCase() !== 'pkarticle' && u.toLocaleLowerCase() !== 'lastupdated').forEach(key => {
          this.columns.push({ header: key.trim().toUpperCase(), field: key.trim() });
        });
        this.loading = false;
      }
    });
  }

  openNew() {
    this.clonedArticle = {} as ArticleInterface;
    this.clonedArticle.isAvailable = true;
    this.submitted = false;
    this.popUp = true;
  }

  onEditInit(article: ArticleInterface) {
    this.clonedArticle = { ...article };
    this.popUp = true;
  }

  saveArticle() {
    this.submitted = true;
    if (this.clonedArticle.articleName &&
      this.clonedArticle.code && this.clonedArticle.image !== "") {
      const newRow = this.clonedArticle;
      if (this.clonedArticle.pkArticle >= 0) { // PK != null is Update
        this.articleService.updateArticle(this.clonedArticle).subscribe((response) => {
          //this.messageToast(response);
          this.readArticles();
        });
      } else { // Create Row
        this.articleService.createArticle(this.clonedArticle).subscribe((response) => {
          //this.messageToast(response);
          this.readArticles();
        });
      }

      this.articles = [... this.articles];
      this.popUp = false;
      this.clonedArticle = {} as ArticleInterface;
    }
  }

  hideDialog() {
    this.popUp = false;
    this.submitted = false;
  }

  /* Clearing the table and hiding the dialog. */
  clear(table: Table) {
    table.clear();
  }

/*   messageToast(message: string) {
    this.messageService.add({ severity: 'success', summary: 'Success', detail: this.translate.instant(message) });
  } */

}
