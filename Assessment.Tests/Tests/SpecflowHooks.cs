using Assessment.Core;
using Assessment.Core.Reportings;
using Assessment.Core.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Assessment.Tests
{
    [Binding]
    public class SpecflowHooks
    {
        private readonly ScreenShotTaker screenShotTaker;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private readonly IObjectContainer _objectContainer;

        public SpecflowHooks(IObjectContainer objectContainer, ScreenShotTaker screenShotTaker)
        {
            _objectContainer = objectContainer;
            this.screenShotTaker = screenShotTaker;

        }

        [BeforeScenario]
        public void Initialize()
        {
            // Intialize driver
            SeleniumExecutor.Initialize();
            //Get scenario Name
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            DeleteContentfromDirectory();
            //To create report directory and add HTML report into it
            extent = new ExtentReports();
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Reports");
            var htmlReporter = new ExtentHtmlReporter(dir + "\\Reports" + "\\Automation Report" + ".html");
            htmlReporter.LoadConfig(dir+"\\extent-config.xml");
            extent.AttachReporter(htmlReporter);
        }
        //Delete content from SS directory
        private static void DeleteContentfromDirectory()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\ExecutionScreenshots");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo d in di.GetDirectories())
            {
                d.Delete(true);
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            string screenShotPath = screenShotTaker.Capture(SeleniumExecutor.Driver(), ScenarioStepContext.Current.StepInfo.Text);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    scenario.Log(logstatus, "Test ended with " + logstatus + "– " + errorMessage);
                    scenario.Log(logstatus, "Snapshot below: " + scenario.AddScreenCaptureFromPath(screenShotPath));
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    scenario.Log(logstatus, "Test ended with " + logstatus);
                    break;
                default:
                    logstatus = Status.Pass;
                    scenario.Log(logstatus, "Snapshot below: " + scenario.AddScreenCaptureFromPath(screenShotPath));
                    break;
            }
        }
        [AfterScenario]
        public static void AfterScenario()
        {
            SeleniumExecutor.Driver().Close();
        }
    }
}
