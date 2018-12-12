import { Component, OnInit } from '@angular/core';
import { Customer } from '../../models/Customer';

@Component({
  selector: 'app-customer2',
  templateUrl: './customer2.component.html',
  styleUrls: ['./customer.component.css']
})
export class Customer2Component implements OnInit {
  customer: Customer = {
    name : '',
    mobilePhone:'',
    eMail:''  
  
}
  customers:Customer[];

  showExtended : boolean = true;
  loaded:boolean = true; // mimi data loading
  
  enabledAdd:boolean = false; // property binding
  
  showCustomerForm: boolean = false;
 
  constructor() { }

  ngOnInit() {
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
    
addCustomer(){
  // this.users.push(this.user);

  this.customers.unshift(this.customer);
  this.customer.isDeleted = false;
  this.customer = {
    name : '',
    mobilePhone: '',
    eMail : ''    
   }
  }  
  
}
