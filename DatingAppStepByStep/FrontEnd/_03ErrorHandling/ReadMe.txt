--------
# 3
--------
API Backend
	Testing: Postman and front-end
		AuthController > Login > centralized error handling. (c.f: change development to production in launchSettings.json for testing)
		
		global exception handling: (instead of try catch block)
			
			go to startup.cs: UseExceptionHandler
		
		
SPA Frontend
	HttpInterceptor: error.interceptor
	
	