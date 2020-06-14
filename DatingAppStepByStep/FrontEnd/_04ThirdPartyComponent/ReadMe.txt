--------
# 4
--------
API Backend
	
	None
		
SPA Frontend
	Alertifyjs
		go to website and test several things
		npm install alertifyjs
		style.css > aletify.min.js and bootstrap.min.css
		aletify.service.ts (wrapping up alertifyjs)
		
		nav.component -->> use above
		register.component -->> use above
	
	Angular JWT
		NOTE: search for angular "2" JWT 
		npm install @auth0/angular-jwt
		
		check expiery or check if it is really JWT ... for better checking JWT token.
		
		auth.service.ts(JwtHelperService) and nav.component.ts
		
		get user name from token (using this library) on upper right side once logged in : auth.service : jwtHelper.decodeToken (actually nav.component.html is using it)
		
		NOTE:authService also should be injected in app.component.ts
		
	NGX bootstrap
		research on it. (especially dropdown)
		
		npm install ngx-bootstrap@3.0.1 --save
		
		based on usage, some code should be inside app.module.ts
		
		it is applied to nav.component.html
		
		nav.component.css (just little enhancement)
		
	Bootswatch
		It is related to theme
		
		research on it.
		
		npm install bootswatch
		
		check on styles.css