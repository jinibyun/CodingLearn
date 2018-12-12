import { Component, OnInit, ViewChild} from '@angular/core';
import { Customer } from '../../models/Customer';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
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

  @ViewChild('customerForm') form:any;
  data:any;
 
  constructor(private customerService:CustomerService) { }

  ngOnInit() {
    this.customerService.getData().subscribe(data => {
      console.log(data);
    });
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = customers;
      this.loaded = true;
    }
      );
}
    

onSubmit({value, valid}: {value:Customer, valid:boolean}){
  if(!valid){
    console.log('Forms is not vaild');

  }
  else{
    value.isDeleted = false;
    this.customers.unshift(value);
    this.form.reset();
  }
}
  
}
