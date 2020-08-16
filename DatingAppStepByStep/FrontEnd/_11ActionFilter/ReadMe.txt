(FE)
	Displaying dates using pipe
		last active date and member since date
	
	member-detail.component.html : date pipe (refer to document)
	member-edit.component.html : date: 'mediumDate'
	
	google: angular timeago pipe : npm install (3rd party component)
	
	
(BE)
	Action filter
		reusability
		update last active date
			userController -->> attribute: [ServiceFilter(typeof(LogUserActivity))]
			it executed everytime action method is executed (just after)
			it should be registered in startup.cs
			