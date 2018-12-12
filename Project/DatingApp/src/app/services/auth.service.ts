import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService} from '@auth0/angular-jwt';

@Injectable()
export class AuthService {

baseUrl = "http://localhost:55551/api/User/";
// ref: https://github.com/auth0/angular2-jwt
jwtHelper = new JwtHelperService() ;
decocedToekn: any;

constructor(private http:HttpClient) { }

    login(model:any){
        return this.http.post(this.baseUrl + 'Login', model)
        .pipe(
            map(
                (response:any) =>
                {
                    const user = response;
                    if(user){
                        localStorage.setItem('token', user.token);
                        this.decocedToekn = this.jwtHelper.decodeToken(user.token);
                        console.log(this.decocedToekn);
                    }
                }
            )
        );
    }

    register(model:any){
        return this.http.post(this.baseUrl + 'Register', model);
    }

    loggedIn(){
        const token = localStorage.getItem('token');
        return !this.jwtHelper.isTokenExpired(token);
    }
}
