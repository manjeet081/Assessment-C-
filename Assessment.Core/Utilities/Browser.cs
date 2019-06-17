using OpenQA.Selenium;

namespace Assessment.Core.Utilities
{
    public static class Browser
    {
        public static void GoToUrl(string url)
        {
            SeleniumExecutor.Driver().Navigate().GoToUrl(url);
        }
    }
}
