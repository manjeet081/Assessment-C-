using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Assessment.Core.Utilities
{
    public static class SeleniumExecutor
    {
        private static IWebDriver webDriver;
        public static ISearchContext SearchContext => Driver();

        public static IWebDriver Driver()
        {
            return webDriver ?? (webDriver = Initialize());
        }

        public static IWebDriver Initialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return webDriver = new ChromeDriver(options);
        }

        public static WebDriverWait GetWaitDriver(int timeout = 0)
        {
            var waitTimeout = timeout == 0 ? 30 : timeout;
            return new WebDriverWait(Driver(), TimeSpan.FromSeconds(waitTimeout));
        }
    }
}