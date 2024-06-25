using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Diagnostics;

namespace B2BAutomationTesting.Hooks
{
    [Binding]
    public class BrowserHook
    {
        private readonly ParallelConfig _parallelConfig;
        public BrowserHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [BeforeScenario]
        public void OpenBrowser()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--headless");

            _parallelConfig.Driver = new ChromeDriver(projectDirectory + @"\\WebDriver", chromeOptions);
            _parallelConfig.Driver.Navigate().GoToUrl("https://b2bticketsdashboard.azurewebsites.net/");
        }

       
        [AfterScenario]
        public void AfterScenario()
        {
            _parallelConfig.Driver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {

        }
    }
}