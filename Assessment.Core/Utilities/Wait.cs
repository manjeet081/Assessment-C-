using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Assessment.Core.Utilities
{
    public static class Wait
    {
        
        public static void ForElementToBeVisible(By elementLocator, int timeout = 0)
        {
            try
            {
                SeleniumExecutor.GetWaitDriver(timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' wasn't visible within timeout limit",
                                                    e);
            }
        }
    }
}
