using DriverHelper.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using B2BAutomationTesting;

namespace B2BAutomationTesting.UIAutomation.Pages
{
    class LogInPage
    {
        public readonly ParallelConfig _parallelConfig;

        public LogInPage(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        private IWebElement logInEmailInput => _parallelConfig.Driver.Find(By.Id("emailInput"));
        private IWebElement logInPasswordInput => _parallelConfig.Driver.Find(By.Id("passwordInput"));
        private IWebElement logInButton => _parallelConfig.Driver.Find(By.Id("loginButton"));
        private IWebElement logInErrorMessage => _parallelConfig.Driver.Find(By.Id("logInErrorMessage"));
        private IWebElement dashComponent => _parallelConfig.Driver.Find(By.Id("dashComponent"));
        private IWebElement selectRetailerMenu => _parallelConfig.Driver.Find(By.Id("selectRetailerMenu"));
        private IWebElement firstRetailerButton => _parallelConfig.Driver.Find(By.Id("retailerButton0"));
        private IWebElement summarySmartTable => _parallelConfig.Driver.Find(By.Id("summarySmartTable"));

        public void LogInSubmit(string email, string password)
        {
            logInEmailInput.SendKeys(email);
            logInPasswordInput.SendKeys(password);
            logInButton.Click();
        }

        public bool CheckLogInSuccess()
        {
            return dashComponent.IsElementPresent();
        }

        public bool CheckLogInFailed()
        {
           return logInErrorMessage.IsElementPresent();
        }

        public bool CheckRetailerOptionArePresent()
        {
            return selectRetailerMenu.IsElementPresent();
        }

        public void SelectFirstRetailer()
        {
            firstRetailerButton.Click();
        }

        public bool LandOnSummaryPage()
        {
            return summarySmartTable.IsElementPresent();
        }
    }
}
