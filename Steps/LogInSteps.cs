using DriverHelper.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using B2BAutomationTesting.UIAutomation.Pages;
using B2BAutomationTesting;
using Serilog;

namespace B2BAutomationTesting.UIAutomation.Steps
{
    [Binding]
    class LogInSteps
    {
        private readonly LogInPage loginPage;
        public readonly ParallelConfig _parallelConfig;

        public LogInSteps(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
            loginPage = new LogInPage(_parallelConfig);
          
        }

        [Given(@"User Enters Credentials ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserEntersCredentialsAnd(string email, string password)
        {
            loginPage.LogInSubmit(email, password);
        }


        [Then(@"User Logs In Successfully")]
        public void UserLogsIn()
        {
            Assert.IsTrue(loginPage.CheckLogInSuccess());
        }

        [Then(@"Failure Message Appears")]
        public void FailureMessageAppears()
        {
            Assert.IsTrue(loginPage.CheckLogInFailed());
        }

        [When(@"User Lands on Select Retailer Page")]
        public void WhenUserLandsOnSelectRetailerPage()
        {
            if (!loginPage.CheckRetailerOptionArePresent())
            {
                Log.Error("Unable to Reach Retailer Selection Screen");
                throw new PendingStepException();
            }
        }

        [Then(@"User Selects First Retailer")]
        public void ThenUserSelectsFirstRetailer()
        {
            loginPage.SelectFirstRetailer();
            Assert.IsTrue(loginPage.LandOnSummaryPage());
        }


    }
}
