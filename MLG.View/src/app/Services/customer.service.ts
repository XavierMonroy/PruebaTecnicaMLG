import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
//import { AccountService } from './account.service';
import { urlAPI } from '../app.constants';
import { HttpClient } from '@angular/common/http';
import { CustomerInterface } from '../Interface/CustomerInterface';

@Injectable({
  providedIn: 'root'
})

export class CustomerService{
    constructor(
        private http: HttpClient//, 
        //private accountService: AccountService
    ) { }

    getAllCustomer(): Observable<CustomerInterface[]>{
        return this.http.get<CustomerInterface[]>(urlAPI + 'customers/GetAllCustomers');    
    }

    updateCustomer(customer: CustomerInterface): Observable<any> {    
        const model = {
            PKCustomer: customer.pkCustomer,
            Name: customer.name,
            LastName: customer.lastName,
            Address: customer.address,
            FKRole: customer.fkRole,
            IsAvailable: customer.isAvailable
        }
    
        return this.http.put(urlAPI + 'customers/UpdateCustomer', model);
    }

    createCustomer(customer: CustomerInterface): Observable<any> {   
        const model = {
            Name: customer.name,
            LastName: customer.lastName,
            Address: customer.address,
            FKRole: customer.fkRole,
            User: customer.user,
            Password: customer.password,
            IsAvailable: customer.isAvailable
        }
    
        return this.http.post(urlAPI + 'customers/Register', model);
    }
}