using DriverHelper.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using B2BAutomationTesting;
using Serilog;

namespace B2BAutomationTesting.UIAutomation.Pages
{
    class CreatingAndValidatingPage
    {
        public readonly ParallelConfig _parallelConfig;

        public CreatingAndValidatingPage(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }
        private IWebElement errorModalConfirm => _parallelConfig.Driver.Find(By.Id("errorModalConfirm"));
        private IWebElement bookingRefFeedback => _parallelConfig.Driver.Find(By.Id("bookingRefFeedback"));
        private IWebElement bookedForFeedback => _parallelConfig.Driver.Find(By.Id("bookedForFeedback"));
        private IWebElement nationailtyFeedback => _parallelConfig.Driver.Find(By.Id("nationailtyFeedback"));
        private IWebElement visitorsFeedback => _parallelConfig.Driver.Find(By.Id("visitorsFeedback"));
        private IWebElement ticketTypesDescriptionFeedback => _parallelConfig.Driver.Find(By.Id("ticketTypesDescriptionFeedback"));
        private IWebElement optionalHeader => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-detail[1]/form[1]/div[1]/div[1]/div[1]/ngb-accordion[1]/div[2]/div[1]/button[1]"));

        private IWebElement guideFeedback => _parallelConfig.Driver.Find(By.Id("guideFeedback"));
        private IWebElement driverFeedback => _parallelConfig.Driver.Find(By.Id("driverFeedback"));

        private IWebElement guideNameInput => _parallelConfig.Driver.Find(By.Id("guideName"));
        private IWebElement driverNameInput => _parallelConfig.Driver.Find(By.Id("driverName"));

        public void ConfirmModal()
        {
            errorModalConfirm.Click();
        }
        
        public bool DetailsErrorMessageExist()
        {
            if(bookingRefFeedback.IsElementPresent() && bookedForFeedback.IsElementPresent() && nationailtyFeedback.IsElementPresent() && visitorsFeedback.IsElementPresent() && ticketTypesDescriptionFeedback.IsElementPresent() && driverFeedback.IsElementPresent() && guideFeedback.IsElementPresent())
            {
                return true;
            }
            Log.Error("Error Message not detected");
            return false;
        }

        public void EnterDriverAndGuideNames()
        {
            optionalHeader.Click();
            guideNameInput.SendKeys("TestName");
            driverNameInput.SendKeys("TestName");
        }

    }
}
