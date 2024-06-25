Automation Testing
Prerequisite: NuGet packages
1.	Selenium.Chrome.WebDriver
2.	Selenium.Support
3.	Selenium.WebDriver
4.	SeleniumExtras.WaitHelpers
5.	SpecFlow.NUnit
6.	SpecFlow.Plus.LivingDocPlugin
7.	SpecFlow.Assist.Dynamic
8.	FluentAssertions
Extensions
1.	SpecFlow for VS 


Running Report
Location: \bin\Debug\net6.0
Run:  livingdoc test-assembly B2BAutomationTesting.UIAutomation.dll -t TestExecution.json
Output: LivingDoc.html

Clear all Driver processes: taskkill /im chromedriver.exe /f

Azure Devops
https://learn.microsoft.com/en-us/azure/devops/pipelines/test/continuous-test-selenium?view=azure-devops
https://docs.specflow.org/projects/specflow-livingdoc/en/latest/sbsguides/sbsazdo.html

