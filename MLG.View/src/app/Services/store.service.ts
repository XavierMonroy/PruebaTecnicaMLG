import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
//import { AccountService } from './account.service';
import { urlAPI } from '../app.constants';
import { ArticleInterface } from '../Interface/ArticleInterface';
import { HttpClient } from '@angular/common/http';
import { StoreInterface } from '../Interface/StoreInterface';

@Injectable({
  providedIn: 'root'
})

export class StoreService{
    constructor(
        private http: HttpClient//, 
        //private accountService: AccountService
    ) { }

    getAllStore(): Observable<StoreInterface[]>{
        return this.http.get<StoreInterface[]>(urlAPI + 'stores/GetAllStores');    
    }

    updateStore(store: StoreInterface): Observable<any> {    
        const model = {
          PKStore: store.pkStore,
          Subsidiary: store.subsidiary,
          Address: store.Address,
          IsAvailable: store.isAvailable
        }
    
        return this.http.put(urlAPI + 'stores/UpdateStore', model);
    }

    createStore(store: StoreInterface): Observable<any> {   
        const model = {
            Subsidiary: store.subsidiary,
            Address: store.Address,
            IsAvailable: store.isAvailable
        }
    
        return this.http.post(urlAPI + 'stores/CreateStore', model);
    }
}