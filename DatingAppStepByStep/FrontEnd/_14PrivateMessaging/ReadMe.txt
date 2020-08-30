(BE)
	class Message (look at the database table: Messages)
	(Same concept as Liker and Likee) - Change User.cs as well (same concept as Liker and Likee)
	
	Note: SenderDeleted and RecipientDeleted exist for both parties
	
	DatingRepository: 
		1. GetMessage()
		2. GetMessagesForUser()
		3. GetMessageThread()
	controller
		MessageController (new)
			We also need LogUserActivity
			First of all, check CreateMessage and test with POSTMAN
			Then, retriveMessage -->> GetMessagesForUser() in DatingRepository
				We need another MessageParams similar to UserParams
		
		Create MessageToReturnDto and mapping section in AutoMapper
		MessageController > GetMessagesForUser()
		
		Test with POSTMAN (multiple scenario : sending ,receiving and outbox, inbox)
		
		Next, finally we need to implement GetMessageThread() method.
			DatingRepository
			MessageController
		Test with POSTMAN
			
(FE)
	create message.ts 	(interface): Message Model
	user.service.ts (getMessage())
	create another resolover: message.resolover.ts
		make sure of app.Module and change route.ts
	message.component.ts
	
	message.component.html
	message.component.css

	Test with browser
	
	user.service.ts (getMessageThread())
	
	create member-messages.component.ts  (refer to member-detail.component. This is a parent and new member-messages is child component)
	
		look at "recipientId"
	
	NOTE: design like chat system): NOTE: first explain "function" later "screen design"
		member-messages.component.html
		chnage member-detail.component (fourth tab) to link member-messages.component.ts
	
	member-messages.component.css
		(look at card-body: overflow-y: scroll)