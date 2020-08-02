Front-end

Updating Resource
	Editing Profile
		member-edit component
			edit nav.component.html with routerLink
			edit route.ts
		member-edit resolover
			It should be registered in app.module
		member-edit css
		
		viewChild
		
	CanDeactivate Route Guard
		route.ts: not saving form data but mistankenly move to other route page. To prevent this...
		
		create prevent-unsaved-changes.ts
		
		another tip: look at HostListener decorator
	
	Persisting changes to the API
		go to back-end section, then after successful testing...
			
		on user service, add updateUser.
		change member-edit component
		

Back-end
	Create UserForUpdateDto.cs
	AutoMapperProfile
	UserController > HttpPut > UpdateUser
	
	Test with Postman