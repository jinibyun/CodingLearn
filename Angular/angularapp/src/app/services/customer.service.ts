import { Injectable } from '@angular/core';
import { Customer } from '../models/Customer';

// Observable
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

customers: Customer[];
data: Observable<any>;
constructor() { 

  this.customers = [
    {
        name : "Amy",
        mobilePhone : "647-123-4567",
        eMail : "amy@gamil.com",
        isDeleted: false
        
      },
      {
        name : "Monica",
        mobilePhone : "647-365-4987",
        eMail : "amoni@gamil.com",
        isDeleted: true
      },
      {
        name : "Mike",
        mobilePhone : "647-998-7157",
        eMail : "mikey@gyahoo.com",
        isDeleted: false
      }
  ]; 

}

  getCustomers(): Observable<Customer[]> {
    return of(this.customers);
  }
    
  addCustomer(customer:Customer){
    this.customers.unshift(customer);
  }

  getData(){
    this.data = new Observable(observer => {
      setTimeout(() => {
        observer.next(1);
      }, 1000);

      setTimeout(() => {
        observer.next(2);
      }, 2000);

      setTimeout(() => {
        observer.next(3);
      }, 3000);

      setTimeout(() => {
        observer.next({name: 'jini'});
      }, 4000);
      
    });

    return this.data;
  }

  
}
