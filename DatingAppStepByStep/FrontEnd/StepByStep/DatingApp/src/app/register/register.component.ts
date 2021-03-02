import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter(); // NOTE: it must be angular/core
  model: any = {};

  // Dependency Injection
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      // console.log('registration successful');
      this.alertify.success('registration successful');
    }, error => {
      // console.log(error);
      this.alertify.error(error);
    });
  }

  cancel() {
    // child to parent: raise event
    this.cancelRegister.emit(false); // e.preventDefault();
    console.log('cancelled');
  }

}
