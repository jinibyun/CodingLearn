Back-End

	UserForRegisterDto (before or after front-end)
		Don't forget autoMapper
		Don't fortet POSTMAN test
		NOTE: createAtRoute method

Front-End

	Reactive Forms (Compared with template form)
		Change Registration Form
		
		register.component
			FormGroup
		check it out app.module has "RactiveFormModule"

	(NOTE, first look at userName and password, passwordMatch)

		Validation
			It is supported by Angular itself
			register.component.html
			
			testing with register.component.html (very bottom section p tag: Leave it on until this chapter ends)
		Custom Validation
			For custom validation, developer should define it.
		
		Validation Feedback
			Using FormBuilder to create form (simply)
			is-invalid and invalid-feedback inside register.component.html
			
			FormBuilder (in register.component.ts)
				FormBuilder.Group create object type of FormGroup
	
	(NOTE, expand other field similar to userName and password, passwordMatch)
		Using FormBuilder, create gender, knownAs... or other columns in register.component.ts and add them in registoer.component.ts
		
		button disabled and enabled using registerForm.valid
		
		Date Problem: Date and time input type
			(Not every browser support: different experience for each browser: input type=date)
			ref: Caniuse.comp
			
			use ngx bootstrap: DatePicker
				app.module: BsDatePickerModule, BrowserAnimationsModule
				css: bs-datepicker.css
				go to register.component.html: bsDatepicker, bsConfig
				
	
	
	Hooking it all up to the API
		Go to UserForRegisterDto in back-end
		After confirmation of UserForRegisterDto, go to register.component.ts : register() method
		
		Finally, test on it

	Fixing the photo issue for newly registered user
		user.png is empty user picture
		member-card.component.html: add user.png
		nav.component.html: add user.png
		member-edit.component.html: add user.png
		member-detail.component.html: add user.png
		
		photo-editor.component.ts: onSuccessItem method, add code if (photo.isMain)...part
		
		
		



