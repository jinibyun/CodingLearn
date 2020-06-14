Front-End

	member-list component, lists component, messages component
	setup route: routes.ts
		import routes from angular/router
		register above 3 component
		
		go to nav.component.html. It should be in [routerLink] abd aslo app.component.html, <router-outlet> should be.
		
		nav.component: it is also injected to use it programmaticlly
		
		route guard (protection): Not for anonymous user to access to it: auth.guard.ts 
			TIP: do not create component but use g guard auth --skipTests  Then, it will ask which interface....
			(Just let them implements CanActivate)
		
		
	