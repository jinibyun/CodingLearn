--------
# 1
--------
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