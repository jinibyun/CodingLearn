===============
# Pre-requisite
===============
Following should be already studied:

C#,
Web API,
SQL Database,
Type Script,
rxJs,
Angular

If one of them is not studied, it would be hard to follow.
Therefore, this project course assumes that the student has already had basic knowledge and/or practical experience on them.

=========
# Dev Tip
=========
Be ready to open following dev tools.

	vscode (some of useful extension. it is optional)
	npm, nodejs and typescript should be installed
	vs.net (with .net core)
	postman(web api client tool or any other web api client)
	chrome browser
	ssms(or any other sql client)
	all source codes should be maintained under git
	github account

	and other tools if necessary such as notepad++ or ConEmu

========================
# Follow the instruction
========================
The instructor will share source via github

API project (back-end) should be opened in vs.net
SPA project (front-end) should be opened in vs code

-----
# 1
-----
API Backend
	> API Code Structure with folder structure
		>> Remind all code first apporach
			>>> DataContext.cs
			>>> files under Models folder: These classess will be converted into table entity
			>>> Data Folder > DataContext.cs/OnModelCreating(): Atnoher extra relationship and other constraint
		>> Repository Pattern under Data Folder: 
			>>> IAuthRepository.cs
			>>> IDatingRePository.cs
			(cf) SOLID: "I" means Interface Segregation
		>> Check it out "startup.cs" how they were injected (Dependency Injection)
			>>> "UsersController.cs": see how IDatingRepository is being used.	
			>>> (Note) For now, skip IMapper. It will be explained later

	> Database Connection String
		>> Open SSMS to check data was created (This is a basically code-first)
	> "Values" table is to confirm if basic processing is working. 
		>> Run DatingApp.API and open PostMan to verify: http://localhost:5000/api/values

SPA Frontend	
	> Open DatingApp-SPA folder with vs.code
	> Make sure
		>> node, npm, tsc and ng
			>>> check out the version of each. (NOTE) Angular version should be 8.*. Others should be the latest.
		>> Just in case
			>>> npm install -g @angular/cli
			>>> Adding C:\Users\{UserName}\AppData\Roaming\npm to System Variable Path
	> In Terminal, npm install. Then "node_modules" folder will be created
	> Overview of each folders and files based on angular architecture.
		>> Go to angular.json file and find "architect" name. Under that folder, we can get to know starting point: "index.html" and "main.ts"
		>> "main.ts" points to "environment.ts" where web api end point is defined
		>> "main.ts" points to "app.module.ts" where all modules are defined
			>>> review all structure of "app.module.ts"
	> In command console, move to \DatingApp-SPA\src\app , then type "ng g c value" to create value.component
		> go to "app.component.html" and see what has been changed for testing. It will have "value" component for testing.
			>>> This is very basic communication between Front-End and Back End
				
----
# 2
----
API Backend
	> AuthController
		> DTO: Data Transfer Object
			>> "UserForLoginDto.cs"
			>> "UserForRegisterDto.cs"
			>> Mapping (IMapper)			
		> AuthRepository.Register: CreatePasswordHash method
		> AuthRepository.Login
			>> JWT Token
				>>> ref: https://jwt.io/
			>> See How token is issued from Login method
			>> Also look how Microsoft is using this token internally
				>>> See services.AddAuthentication.AddJwtBearer in Startup.cs
				
SPA Frontend
	> go to "app.component.html" and comment/uncomment
	> npm install bootstrap and font-awesome
		>> go to "style.css" to see how it import relevant css files
	> add service under _services folder
		>> "auth.service"
			>>> define login and register 
			>>> store token in localstorage
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

----
# 3
----
API Backend
	> global exception handling
		>> See Startup.cs : app.UseExceptionHandler
			>>> FYI, Extension.cs is created for defining extension method
SPA Frontend
	> Next -->> Module 5's error.interceptor.ts.......
