import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // parent to child
  // @Input() valuesFromHome:any;

  // child to parent: raise event
  @Output() cancelRegister = new EventEmitter();

  model:any = { };
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register(){
    
    this.authService.register(this.model)
    .subscribe(() =>{
      // console.log("registration successful");
      this.alertify.success('registration successfully');
    }, error =>{
      // console.log("error");
      this.alertify.error(error);
    }
    );
  }
  cancel(){
    this.cancelRegister.emit(false);
  }
}
