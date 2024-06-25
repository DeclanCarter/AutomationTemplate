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
    class SummarySmartTablePage
    {
        public readonly ParallelConfig _parallelConfig;

        public SummarySmartTablePage(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }
        public IWebElement summaryPageError => _parallelConfig.Driver.Find(By.XPath("//tbody/tr[1]"));

        public bool SendMessages()
        {
            if (summaryPageError.IsElementPresent()){
                return true;
            }
            return false;

        }
    }
}
