Front-end
	Types in Typescript
		
		static typing / dynamic typing
		e.g) interface (static typing): make it more strict for "type safety"
		
		(benefit of using interface)
		compile time checking
		intellisense
		
		e.g)
		Compare with back-end DTO (very similar)
			user.ts / photo.ts
		
		
	Retrieving users from the API
		create service: user.service.ts
		modify member-list.component to use service
		create member-card.component
		
		NOTE: where sending token...
		(https://github.com/auth0/angular2-jwt)
		app.module.ts : function tokenGetter()
			
		
	Bootstrap for member card
		Nice look and feel: Hovering image...
		member-card.component.css
		
		
	Detailed view of the users
		member-detail component
			look at route.ts to see how to pass parameter
			look at member-card html to see how to use routerLink
		ngx-bootstrap
		style.css : some extra setting for tab
		
	route resolver
		Please look at how routing resolve is being used in member-detail component
		
		create member-detail.resolover
		create member-detail.resolve
	Photo gallery
		ngx-gallery: npmjs.com/package/ngx-gallery
		
	