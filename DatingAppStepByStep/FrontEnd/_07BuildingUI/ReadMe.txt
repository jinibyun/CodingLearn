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
		create service: user.service.ts (define apiUrl in environment.ts: look at comment area)
		modify member-list.component to use service
		create member-card.component
		
		NOTE: where sending token...
		(https://github.com/auth0/angular2-jwt)
		app.module.ts : function tokenGetter()
			-->> user.Service.ts (httpOptions can be commented out because of this: Simplification)
			-->> double check chrome developer... on testing
		
	Bootstrap for member card
		Nice look and feel: Hovering image...
		member-card.component.css
		
		
	Detailed view of the users
		member-detail component
			look at route.ts to see how to pass parameter
			look at member-card html to see how to use routerLink
		ngx-bootstrap
		style.css : some extra setting for tab: ngx bootstrap (also add some value to style.css)
		
	route resolver: BEFORE data is activated via route, it resolves data at first
		Please look at how routing resolve is being used in member-detail component
		
		create member-detail.resolover
		create member-detail.resolve
	Photo gallery
		ngx-gallery: npmjs.com/package/ngx-gallery
		
	