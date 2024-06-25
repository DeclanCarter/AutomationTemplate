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
    internal class BookingActionsPage
    {
        public readonly ParallelConfig _parallelConfig;

        public BookingActionsPage(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }
        private IWebElement addNewBookingButton => _parallelConfig.Driver.Find(By.Id("AddNewBookingButton"));
        private IWebElement bookingRefInput => _parallelConfig.Driver.Find(By.Id("bookingRef"));
        private IWebElement bookedForInput => _parallelConfig.Driver.Find(By.Id("bookedFor"));
        private IWebElement nationalityDropdown => _parallelConfig.Driver.Find(By.Id("nationality"));
        private IWebElement firstNationalityOption => _parallelConfig.Driver.Find(By.Id("nationalityOption0"));
        private IWebElement visitorsInput => _parallelConfig.Driver.Find(By.Id("visitors"));
        private IWebElement ticketTypesDropdown => _parallelConfig.Driver.Find(By.Id("ticketTypesDescription"));
        private IWebElement ticketOption => _parallelConfig.Driver.Find(By.Id("ticketOption0"));
        private IWebElement submitButton => _parallelConfig.Driver.Find(By.Id("detailsPageSubmit"));
        private IWebElement bookingReferenceFilter => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-summary[1]/angular2-smart-table[1]/table[1]/thead[1]/tr[2]/th[2]/angular2-smart-table-filter[1]/div[1]/default-table-filter[1]/input-filter[1]/input[1]"));
        private IWebElement firstBookingReference => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-summary[1]/angular2-smart-table[1]/table[1]/tbody[1]/tr[1]/td[2]/angular2-smart-table-cell[1]"));
        private IWebElement deleteAction => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-summary[1]/angular2-smart-table[1]/table[1]/tbody[1]/tr[1]/td[1]/angular2-st-tbody-edit-delete[1]/a[1]"));
        private IWebElement deleteConfirmButton => _parallelConfig.Driver.Find(By.Id("YesDeleteModal"));
        private IWebElement deleteSuccessfulButton => _parallelConfig.Driver.Find(By.Id("DeleteSuccessfulButton"));
        private IWebElement updateAction => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-summary[1]/angular2-smart-table[1]/table[1]/tbody[1]/tr[1]/td[1]/angular2-st-tbody-custom[1]/a[3]"));
        private IWebElement firstRowVisitors => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-summary[1]/angular2-smart-table[1]/table[1]/tbody[1]/tr[1]/td[5]/angular2-smart-table-cell[1]/table-cell-view-mode[1]/div[1]/div[1]/div[1]"));
        private IWebElement copyAction => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-summary[1]/angular2-smart-table[1]/table[1]/tbody[1]/tr[1]/td[1]/angular2-st-tbody-custom[1]/a[1]"));
        private IWebElement copyConfirmModal => _parallelConfig.Driver.Find(By.Id("YesCopyModal"));
        private IWebElement viewAction => _parallelConfig.Driver.Find(By.XPath("/html[1]/body[1]/app-root[1]/app-home[1]/div[1]/div[1]/app-booking-summary[1]/angular2-smart-table[1]/table[1]/tbody[1]/tr[1]/td[1]/angular2-st-tbody-custom[1]/a[2]/i[1]"));
        private IWebElement viewBookingRefValue => _parallelConfig.Driver.Find(By.Id("bookingRefValue"));
        private IWebElement viewVisitorValue => _parallelConfig.Driver.Find(By.Id("visitorsValue"));
        private IWebElement goBackButton => _parallelConfig.Driver.Find(By.Id("goBackButton"));
        private IWebElement viewBookedForValue => _parallelConfig.Driver.Find(By.Id("bookedForValue"));
        public void ClickAddNewButton()
        {
            Thread.Sleep(3000);
            addNewBookingButton.Click();
        }
        
        public void FillInMandatoryFields(string bookingRef)
        {
            bookingRefInput.SendKeys(bookingRef);
            bookedForInput.SendKeys("0606" + (DateTime.Now.Year + 1).ToString());
            nationalityDropdown.Click();
            firstNationalityOption.Click();
            visitorsInput.SendKeys("1");
            ticketTypesDropdown.Click();
            ticketOption.Click();
            Thread.Sleep(1000);
        }

        public void SubmitDetailsPage()
        {
            submitButton.Click();
        }
        public bool CheckBookingRefInTable(string bookingRef)
        {
            bookingReferenceFilter.SendKeys(bookingRef);
            Thread.Sleep(2000);
            if (firstBookingReference.Text == bookingRef)
            {
                bookingReferenceFilter.Clear();
                return true;
            }
            Log.Error(bookingRef + " not appearing when search");
            return false;
        }

        public bool DeleteBooking()
        {
            Thread.Sleep(1000);
            deleteAction.Click();
            Thread.Sleep(1000);
            deleteConfirmButton.Click();
            if (deleteSuccessfulButton.IsElementPresent())
            {
                deleteSuccessfulButton.Click();
                return true;
            }

            Log.Error("Unable to locate delete action for booking");
            return false;

        }


        public void UpdateBooking()
        {
            updateAction.Click();
            Thread.Sleep(1000);
            visitorsInput.SendKeys("5");
        }
        public bool VerifyVistorsUpdated()
        {
            if(firstRowVisitors.Text == "15")
            {
                return true;
            }
            Log.Error("Booking did not update according to test");
            return false;
        }

        public void CopyBooking(string bookingRef)
        {
            copyAction.Click();
            Thread.Sleep(1000);
            copyConfirmModal.Click();
            bookingRefInput.SendKeys(bookingRef);
        }

        public void ViewBooking()
        {
            viewAction.Click();
            Thread.Sleep(2000);

        }
        public bool verifyViewBooking(string bookingRef)
        {
            if (viewBookingRefValue.Text == bookingRef && viewBookedForValue.Text == "06/06/" + (DateTime.Now.Year + 1).ToString())
            {
                goBackButton.Click();
                return true;
            }
            Log.Error("Unable to Confirm Booking information of View Page");
            return false;
        }

    }
}
