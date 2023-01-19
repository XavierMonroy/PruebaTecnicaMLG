import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './Components/home-page/home-page.component';
import { ArticlesComponent } from './Components/articles/articles.component';
import { CustomersComponent } from './Components/customers/customers.component';
import { StoreComponent } from './Components/store/store.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormatDataInterceptor } from './Interceptors/formatData.interceptor';
import { HeaderInterceptor } from './Interceptors/header.interceptor';

import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogModule } from 'primeng/dialog';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    ArticlesComponent,
    CustomersComponent,
    StoreComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule,
    ToolbarModule,
    DialogModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: FormatDataInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
