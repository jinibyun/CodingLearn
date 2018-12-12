import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { JwtHelperService} from '@auth0/angular-jwt';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  jwtHelper = new JwtHelperService();
  constructor (private authService: AuthService){

  }

  // NOTE: why this process is needed even if it exist in "auth.service.ts", when the whole page refresh, it is needed. (NOT only when logging in)
  ngOnInit(){
    const token = localStorage.getItem('token');
    if(token){
      this.authService.decocedToekn = this.jwtHelper.decodeToken(token);
    }
  }
}
