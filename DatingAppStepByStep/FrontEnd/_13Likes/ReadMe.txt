(BE)
	Relationship in EF
		- c.f: so far we studied user and photos (one to many)
		- user to user (like module) this is many to many. Therefore we created "Like"
		
		- look at "OnModelCreating"(ModelBuilder builder) part in DataContext.cs (This is actually for code-first methologies). You can see data table in sql directly.
		
			class "Like" is required to create
			look at User.cs: Liker and Likee property
		
		Repository:  DatingRepository > GetLike(): Who like who
		Controller:  UserController > LikeUser()
		
		Test with POSTMAN	 (NOTE: This is "post" action)
			NOTE: you do not have to send any post body data. Just make it {} (empty json object)
			
		To get retrieve a list of users I like, go to "UserParams" class > Likees and Likers property
			DatingRepository > GetUsers() method > userParams.Likers and userParams.Likees and "new" method : GetUserLikes()

		Test with POSTMAN
			e.g. http://..../api/users?likers=true or http://..../api/users?likees=true

(FE)
	1. Add like
		user.services.ts
			add sendLike() method
		member-card.component (all method or code should be reviewed)
			main method is sendLike() method
		member-card.html
			add event call : sendlike()
	2. List like
		user.service.ts > getUsers > add another parameter named "likesParam" and relevant added code
		
		create lists.resolver.ts (similar concept as Member-list-resolver.ts)
		add above new resolver in route.ts
		(don't forget register in app.module)
		
		modify list.component.ts
		list.component.html
		
		
		
		