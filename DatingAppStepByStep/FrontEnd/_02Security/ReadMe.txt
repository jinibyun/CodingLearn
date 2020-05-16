--------
# 2
--------
API Backend
	> Hash and Salt
	> AuthController / IAuthRepository
		> Repository Pattern & DI (Dependency Injection)		
		> AuthRepository.Register(): CreatePasswordHash() method
		> AuthRepository.Login()
		> AuthController.Register()
		> DTO: Data Transfer Object
			>> "UserForLoginDto.cs"
			>> "UserForRegisterDto.cs"
			>> Mapping (IMapper)
			>> Validation (with System.ComponentModel.DataAnnotations)
		> JWT Token
			>> ref: https://jwt.io/
		> See How token is issued from Login method: AuthController.Register()
		> Also look how Microsoft is using this token internally
		> See services.AddAuthentication.AddJwtBearer in Startup.cs
			>> Test with ValuesContoller
		> Make sure of testing via POSTMAN		
			>> Register() and Login()
		
SPA Frontend
	> go to "app.component.html" and comment/uncomment
	> npm install bootstrap and font-awesome
		>> go to "style.css" to see how it import relevant css files
	> add service under _services folder
		>> "auth.service"
			>>> define login and register 
			>>> store token in localstorage (do not look at Angular JWT yet)
	> Confirm auth.service is registered in app.module.ts
	> add three components
		>> home, nav and register
	> go to app.component.html to link two components: app-nav and app-home
		>> router-outlet: just bypass. Think of it as app-home
	> nav.component has bootstrap UI
	> nav.component are using "authService" in constructor
	> home.component 
		>> link to register.component if not logged in
			>>> see how register.component is call authService.register method
			>>> see how register.component is rasing event "cancelRegister" and how home.component is handling
				(This is about communication between two components)
				
	> Login and Register Test
