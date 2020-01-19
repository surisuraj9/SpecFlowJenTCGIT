using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SpecFlowJenTCGIT.Base;
using SpecFlowJenTCGIT.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowJenTCGIT.StepDefs
{
    [Binding]
    public sealed class Hooks:TestBase
    {
        private static ScenarioContext _scenarioContext;
        Random random = new Random();
        private static ExtentReports extent;
        private static ExtentHtmlReporter extentHtmlReporter;

        private static ExtentTest feature;
        private static ExtentTest scenario;
        public Hooks():base()
        {
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("launching chrome");
            TestBase.initialization();

            string dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Reports");
            string path = dir + "Reports\\index.html";
            extentHtmlReporter = new ExtentHtmlReporter(path);
            extentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AddSystemInfo("Environment", "TestEnv");
            extent.AddSystemInfo("Username", "Suraj");
            extent.AttachReporter(extentHtmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title,
                    featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }   
        }

        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (_scenarioContext.TestError != null)
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                        String Path = TestUtil.TakeScreenshotAtEndOfTest(random.Next().ToString());
                        scenario.AddScreenCaptureFromPath(Path);
                    }
                    else
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                    break;
                case ScenarioBlock.When:
                    if (_scenarioContext.TestError != null)
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                        String Path = TestUtil.TakeScreenshotAtEndOfTest(random.Next().ToString());
                        scenario.AddScreenCaptureFromPath(Path);
                    }
                    else
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                    break;
                case ScenarioBlock.Then:
                    if (_scenarioContext.TestError != null)
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                        String Path = TestUtil.TakeScreenshotAtEndOfTest(random.Next().ToString());
                        scenario.Log(Status.Info, "Screenshot: ", MediaEntityBuilder.CreateScreenCaptureFromPath(".\\" + Path).Build());
                        scenario.AddScreenCaptureFromPath(Path);
                    }
                    else
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                    break;
                default:
                    if (_scenarioContext.TestError != null)
                    {
                        scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message+"\n" + _scenarioContext.TestError.StackTrace);
                        String Path = TestUtil.TakeScreenshotAtEndOfTest(random.Next().ToString());
                        scenario.AddScreenCaptureFromPath(Path);
                    }
                    else
                    {
                        scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                    break;

            }
        }   

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("closing the browser");
            TestBase.driver.Quit();
            extent.Flush();

        }


    }
}
