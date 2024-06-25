@SmartTable
Feature: SummarySmartTable

Background: 
Given User Enters Credentials "fabio@retail-int.com" and "Pa$$w0rd"


Scenario: Smart Table is Populated on load
	Then Verify Table is Populated
