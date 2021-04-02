import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Customer} from './customer';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  customerUrl:string = 'http://localhost:1234/customers';
  ordersUrl:string = 'http://localhost:1234/orders';

  constructor(private http: HttpClient) { }

  getCustomers():Observable<Customer[]> {
    return this.http.get<Customer[]>(this.customerUrl)
  }

  getCustomer(id:number):Observable<Customer> {
    return this.http.get<Customer>(this.customerUrl + "/" + id);
  }

  deleteCustomer(id:number): Observable<any> {
    return this.http.delete(this.customerUrl + "/" + id);
  }

  updateCustomer(customer:Customer): Observable<any> {
    return this.http.put(this.customerUrl + "/" + customer.id, customer);
  }
  
}
