@Login
Feature: LogIn

Scenario: Testing Successful Log In
	Given User Enters Credentials "fabio@retail-int.com" and "Pa$$w0rd"
	Then User Logs In Successfully

Scenario: Testing Failed Log In
	Given User Enters Credentials "d.carter@retail-int.com" and "WrongPa$$w0rd"
	Then Failure Message Appears 

Scenario: Testing Multiple Retailer Log In
	Given User Enters Credentials "d.carter@retail-int.com" and "Pa$$w0rd"
	When User Lands on Select Retailer Page
	Then User Selects First Retailer
