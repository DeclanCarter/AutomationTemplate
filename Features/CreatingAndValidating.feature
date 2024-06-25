@CreationAndValidation
Feature: CreatingAndValidating

Background: 
Given User Enters Credentials "fabio@retail-int.com" and "Pa$$w0rd"
	When Selecting Add New Button


Scenario: Add New Booking And Deleting
	When Create Booking "AutoTest"
	And Search "AutoTest" in Table
	Then Delete Booking

Scenario: Form Validation Check
When Enter Optional Fields Data
When Submit Form
Then Error Messages Appear

