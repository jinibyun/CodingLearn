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
		
		
	
Front-End
	Uploader
		photo-editor component
		photo-editor.component.css
		3rd party uploader
			go to ng2-file upload (valor-software). check demo as well and npm install...
		
		
	setting main photo
	
	Any to any component communication
	
	deleting photo