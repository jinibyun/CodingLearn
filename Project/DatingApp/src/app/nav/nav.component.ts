import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model : any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService, private router:Router) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(
      next => {
        // console.log('login successful');
        this.alertify.success('login successful');
        
      }, error =>{
        // console.log('faile to login');
        // NOTE: see error.interceptor.ts 
        // console.log(error);
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/members']);
      }
    );
  }

  loggedIn(){
    // const token = localStorage.getItem('token');
    // return !!token; // !! means token is empty, return false.
    return this.authService.loggedIn();
  }

  logout(){
    localStorage.removeItem('token');
    // console.log('log out');
    this.alertify.message('logged out');
    this.router.navigate(['home']);
  }
}
