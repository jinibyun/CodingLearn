import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  // dependency injection
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  // after successful login, please make sure token is saved in local storage
  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log('Failed to login');
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // !! means retrun true of false
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
