@SmartTableActions
Feature: BookingActions

Background: 
Given User Enters Credentials "fabio@retail-int.com" and "Pa$$w0rd"
	When Selecting Add New Button
	And Create Booking "AutoTest"
	And Search "AutoTest" in Table


Scenario: Update Test Booking 
	When Update Booking
	And Search "AutoTest" in Table
	And Verify Update Change
	Then Delete Booking

Scenario: Copy Test Booking
	When Copy Booking "AutoTestCopy"
	And Search "AutoTestCopy" in Table
	And Delete Booking
	And Search "AutoTest" in Table
	Then Delete Booking

Scenario: View Test Booking
	When View Booking "AutoTest" 
	And Search "AutoTest" in Table
	Then Delete Booking



