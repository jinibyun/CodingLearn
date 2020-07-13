Back-End
	Where to store
		These days, cloud file system: cloudinary
		After signup, then get necessary value and go to appSettings.json and set value: CloudinarySettings
			
		Also create CloudinarySettings.cs and register it to Startup.cs
		
		PublicId is added to Photo.cs
		
		download nuget package: Cloudinary.Dotnet (get latest)
		
		Create PhotoController
		
		PhotoForCreationDto
		
		Use ImageUploadResult, other class... documented from cloudinary
		
		
		Testing POSTMAN with file upload (inside body tab, form-data and choose file instead of text: Key must be "File")
		
		After setting main photo in FE, change AuthController.cs login method to return user object (in order to return photoUrl)
		
		Before deleting photo, go to PhotosController.cs > DeletePhoto method
			Always test it with postman before going in FE
			Check it out in database and cloudinary
	
Front-End
	Uploader
		photo-editor component
		photo-editor.component.css
		3rd party uploader
			go to ng2-file upload (valor-software). check demo as well and npm install...
		
	setting main photo 
		user.service.ts (setMainPhoto method)
		photo-editor component (setMainPhoto method)
		
		NOTE: immediate change should be applied on setting main photo to same page(parent) and also another nav component : We need @output property or better way...
		
		change auth.Service to have user object (not only token)
		change nav.component (logout) and html to have PhotoUrl
	
	Any to any component communication (it means not just parent and child. Literally "any" to "any")
		For example, in out case setMainPhoto should apply both paretn page and nav component as well. The answer is "service"
		
			AuthService
				BehaviroSubject
					1. AuthService.ts
						photoUrl
			
			Then, go to nav.component  
				look how currentPhotoUrl is being subscribed
			Then, go to app.component
				look how user.photoUrl is being updated
			Then, go to member-edit component
				look how currentPhotoUrl is being updated and subscribed
			Then, go to photo-editor component
				Change setMainPhoto method
			
	deleting photo
	
		After working on it Back-End, then go to 
		User.service.ts (deletePhoto method)
		photo-editor component (deletePhoto method)
		