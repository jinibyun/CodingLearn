import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


// CanActivate is about route protection
// use this on app-routing.module.ts
// Not for anonymous user to access to it
@Injectable({
  providedIn: 'root' // we do not need to register it over app.module
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router,
    private alertify: AlertifyService) {}

	// returing boolean is good enough
	// c.f: canActivate returuns "union" type. Among them, just pick up boolean type
  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertify.error('You shall not pass!!!');
    this.router.navigate(['/home']); // send back them to home
    return false;
  }
}
