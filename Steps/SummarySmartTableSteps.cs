using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BAutomationTesting.UIAutomation.Pages;
using NUnit.Framework;

namespace B2BAutomationTesting.UIAutomation.Steps
{
    [Binding]
    class SummarySmartTableSteps
    {
        private readonly SummarySmartTablePage _summarySmartTablePage;
        public readonly ParallelConfig _parallelConfig;

        public SummarySmartTableSteps(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _summarySmartTablePage = new SummarySmartTablePage(_parallelConfig);

        }

        [Then(@"Verify Table is Populated")]
        public void ThenVerifyTableIsPopulated()
        {
            Assert.IsTrue(_summarySmartTablePage.SendMessages());
        }

    }
}
