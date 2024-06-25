using DriverHelper.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using B2BAutomationTesting;
using B2BAutomationTesting.UIAutomation.Pages;
using Serilog;

namespace B2BAutomationTesting.UIAutomation.Steps
{
    [Binding]
    class BookingActionsSteps
    {

        private readonly Pages.BookingActionsPage detailsPage;
        public readonly ParallelConfig _parallelConfig;

        public BookingActionsSteps(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
            detailsPage = new Pages.BookingActionsPage(_parallelConfig);

        }

        [When(@"Selecting Add New Button")]
        public void WhenSelectingAddNewButton()
        {
            detailsPage.ClickAddNewButton();
        }


        [When(@"Create Booking ""([^""]*)""")]
        public void WhenCreateBooking(string bookingRef)
        {
            detailsPage.FillInMandatoryFields(bookingRef);
            detailsPage.SubmitDetailsPage();
        }

        [When(@"Search ""([^""]*)"" in Table")]
        public void WhenSearchExists(string bookingRef)
        {
            if (!detailsPage.CheckBookingRefInTable(bookingRef))
            {
                Log.Error("Could not find " + bookingRef + " in summary table");
                throw new PendingStepException();
            }
        }


        [Then(@"Delete Booking")]
        public void ThenDeleteBooking()
        {
            Assert.IsTrue(detailsPage.DeleteBooking());
        }

        [When(@"Delete Booking")]
        public void WhenDeleteBooking()
        {
            detailsPage.DeleteBooking();
        }


        [When(@"Update Booking")]
        public void WhenUpdateBooking()
        {
            detailsPage.UpdateBooking();
            detailsPage.SubmitDetailsPage();
        }

        [When(@"Verify Update Change")]
        public void WhenVerifyUpdateChange()
        {
            if (!detailsPage.VerifyVistorsUpdated())
            {
                Log.Error("Could not Verify Visitors number was Updated with");
                throw new PendingStepException();
            }
        }

        [When(@"Copy Booking ""([^""]*)""")]
        public void WhenCopyBooking(string bookingRef)
        {
            detailsPage.CopyBooking(bookingRef);
            detailsPage.SubmitDetailsPage();
        }
        [When(@"View Booking ""([^""]*)""")]
        public void WhenViewBooking(string bookingRef)
        {
            detailsPage.ViewBooking();
            if (!detailsPage.verifyViewBooking(bookingRef))
            {
                Log.Error("Could not Verify View Page with correct information");
                throw new PendingStepException();
            }
        }

        [When(@"View Booking")]
        public void WhenViewBooking()
        {
            detailsPage.ViewBooking();
        }



    }
}
