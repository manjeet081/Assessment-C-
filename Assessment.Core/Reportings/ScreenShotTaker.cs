using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Core.Reportings
{
    public class ScreenShotTaker
    {
        /// To capture the screenshot for extent report and return actual file path

        public string Capture(IWebDriver driver, string screenShotName)
        {
            string finalpth;
            string localpath;
            Thread.Sleep(4000);
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\ExecutionScreenshots\\");
            finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\ExecutionScreenshots\\" + screenShotName + ".png";
            localpath = new Uri(finalpth).LocalPath;
            localpath = localpath + "#\\Assessment.Tests\\ExecutionScreenshots\\" + screenShotName + ".png";
            screenshot.SaveAsFile(localpath);
            return localpath;
        }

    }
}