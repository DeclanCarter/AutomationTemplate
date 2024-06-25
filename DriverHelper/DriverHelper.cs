
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Serilog;



namespace DriverHelper.Extensions
{
    public static class DriverHelper
    {

        public static IWebElement Find(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement element = null;
            wait.Until(d =>
            {
                try
                {
                    element = d.FindElement(by);
                    if (element.Displayed &&
                        element.Enabled)
                    {
                        return element;
                    }
                }
                catch (NoSuchElementException)
                {
                    
                    Log.Error("Unable to find. Id/Path is" + by);
                    return null;
                }
                return null;

            });
            return element;
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            if (element.Displayed && element.Enabled)
                return true;

            Log.Error(element + "not Present");
            return false;

            throw new AssertionException(String.Format("AssertElement Not present Exception"));
        }
        public static IReadOnlyCollection<IWebElement> FindMultiple(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IReadOnlyCollection<IWebElement> element = null;
            try
            {
                wait.Until(d =>
                {
                    try
                    {
                        element = d.FindElements(by);

                        if
                        (
                        element.Count > 0 &&
                        element.ElementAt(0).Displayed &&
                        element.ElementAt(0).Enabled
                        )

                        {
                            return element;
                        }
                    }

                    catch (NoSuchElementException)
                    {

                    }
                    return null;

                });
            }
            catch (WebDriverTimeoutException)
            {

            }

            return element;
        }



    }

}
