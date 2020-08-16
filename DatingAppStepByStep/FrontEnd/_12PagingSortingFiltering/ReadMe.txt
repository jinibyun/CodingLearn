1. Paging
(B.E)
	DatingRepository > GetUsers() is using "PagedList" class
	(review PagedList class)
		
	UserControll.cs > GetUsers() is also returning page information (size, count,...) in Response Header
	For this, look at "AddPagination" method in extension.cs
		We create another helper class: PaginationHeader.cs
	Making parameter as class: UserParams.cs
	
	IDataingRepository >change to Task<PlagedList<User>> GetUsers(UserParams userParams);
	According to this, Change DatingRepository.cs > GetUsers() method
	
	(TIP)Angular will use camalCasing, therefore AddPagination method (Extension.cs), set CamelCasing for response header.
	
	NOTE: Testing for pagination via postman (please look at "Header" section in response)

(F.E)
	In models folder, create Pagination.ts - similar to PaginationHeader (from B.E.) as above
	
	user.service.ts > change getUsers() method: look at comment
		
	member-list.resolver.ts > change resolve method
	
	member-list.component.ts
	
	Confirmation in web browser > chrome developer network tab. Header > Pagination section
	
	If everyting is ok, then Pagination Link in browser
		ngx bootstrap > pagination component (custom links content section) copy and paste code
			member-list.component.html
				<div class="d-flex justify-content-center"> section
				It is related to member-list.component.ts : this.pagination, look at pageChanged event
		NOTE: app.module: PaginationModule.		
		
	When testing, look at chrome developer network tab. Header > Pagination section
			
2. Filtering
(B.E)
	go to UserParams.cs: Gender, MinAge, MaxAge
	DatingRepository: GetUsers() > Gender, MinAge, MaxAge
	Testing with POSTMAN


(F.E)		
	member-list.component.html > add filtering option (form) template form (with two way binding)
	member-list.component.ts > look at localStorage.GetItem / genderList (object array) / userParams
									    also look at resetFilters()
	user.service.ts > getUsers() > if (userParams != null) ...
	
3. Sorting
(B.E)
	go to UserParams.cs: OrderBy
	DatingRepository: GetUsers() > OrderBy
(F.E)
	ngx-bootstrap > buttons > Radio Button
	
	app.module: ButtonModule.for...
	
	member-list.component > orderby
	member-list.component.html > Last Active, Newest Member
		