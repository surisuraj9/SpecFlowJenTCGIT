using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowJenTCGIT.Base;
using SpecFlowJenTCGIT.Util;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowJenTCGIT.StepDefs
{
    [Binding]
    public class GeneralSteps: TestBase
    {
        [Given(@"user opens browser with url")]
        public void openUrl()
        {
            driver.Url= ConfigurationManager.AppSettings["url"];
        }
        
        [Then(@"user enters ""(.*)"" as ""(.*)"" and ""(.*)"" as ""(.*)"" in ""(.*)"" page")]
        public void validateLogin(string uname, string uElementName, string pass, string pElementName, string pageName)
        {
            TestUtil.getPageDescriptor(uElementName, pageName).Clear();
            TestUtil.getPageDescriptor(uElementName, pageName).SendKeys(uname);
            TestUtil.getPageDescriptor(pElementName, pageName).Clear();
            TestUtil.getPageDescriptor(pElementName, pageName).SendKeys(pass);
        }
        
        [Then(@"user clicks on ""(.*)"" in ""(.*)"" page")]
        public void clickMethod(string elementName, string pageName)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", TestUtil.getPageDescriptor(elementName, pageName));
            //		TestUtil.getPageDescriptor(elementName, pageName).click();
            Thread.Sleep(10000);
        }

        [Then(@"user validates ""(.*)"" as ""(.*)"" in ""(.*)"" page")]
        public void validateMethod(string elementName, string value, string pageName)
        {
            TestUtil.switchToFrame();
            Assert.AreEqual(TestUtil.getPageDescriptor(elementName, pageName).Text, value);
        }
    }
}
