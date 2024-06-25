using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using B2BAutomationTesting.UIAutomation.Pages;
using B2BAutomationTesting;
using NUnit.Framework;

namespace B2BAutomationTesting.UIAutomation.Steps
{
    [Binding]
    class CreatingAndValidatingSteps
    {
        private readonly CreatingAndValidatingPage _summaryTablePage;
        private readonly Pages.BookingActionsPage _detailsPage;
        public readonly ParallelConfig _parallelConfig;

        public CreatingAndValidatingSteps(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _summaryTablePage = new CreatingAndValidatingPage(_parallelConfig);
            _detailsPage = new Pages.BookingActionsPage(_parallelConfig);

        }
        [When(@"Submit Form")]
        public void WhenSubmitForm()
        {
            _detailsPage.SubmitDetailsPage();
        }
        [Then(@"Error Messages Appear")]
        public void ThenErrorMessagesAppear()
        {
            Assert.IsTrue(_summaryTablePage.DetailsErrorMessageExist());
        }

        [When(@"Enter Optional Fields Data")]
        public void WhenEnterOptionalFieldsData()
        {
            _summaryTablePage.EnterDriverAndGuideNames();
        }



    }
}
