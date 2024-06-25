@MessageFunctionality
Feature: MessageChatWindow

Background: 
Given User Enters Credentials "fabio@retail-int.com" and "Pa$$w0rd"
	When Selecting Add New Button
	And Create Booking "AutoTest"
	And Search "AutoTest" in Table
	And View Booking
	


Scenario: Sending and Searching Messages
	When Check Sending Two Messages "First Test Message" and "Second Test Message"
	And Verify Searching Messages
	And Search "AutoTest" in Table
	Then Delete Booking

