Back-end
	All is about extending api

	User Class and Photo Class
			
	Casecade delete ? (is not on mssql server automatically)
		
	Seeding Data
		use json generator web site to generate UserSeedData.json
		create UserSeedData.json for eache male and female
		Seed.cs and in startup.cs call Seed (seeder.SeedUsers();).
		FYI, look at program.cs inside main method (comment)
		
	New Repo
		DataContext
		IDatingRepository, DatingRepository : Focus necessary class: User and Photo (Later, other things can be explained)
		
		NOTE: DI on startup.cs
		
	UserController
		NOTE: when developing based on core 3.x, then use AddNewtonsoftJson (it can be found in startup.cs)
		
		Filter: LogUserActivity
		Testing POSTMAN (at least GetUser())
		You may need token (use login at first to get token)
	Automapper
		IMapper(Automapper) and DTO
			d.g. Password is returned
			UserForListDto
			UserForDetailedDto
			AutoMapperProfile: Define source and destination: User and Photo only. Others can be considered later.
			
				check out detail mapping on it.
			
			test always with POSTMAN
			
		Automapper
			DI in startup.cs