using OpenQA.Selenium;
using SpecFlowJenTCGIT.Base;
using SpecFlowJenTCGIT.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowJenTCGIT.Util
{
    public class TestUtil:TestBase
    {
        public static long PAGE_LOAD_TIMEOUT = 60;
        public static long IMPLICIT_WAIT = 60;
		public static IWebElement element;
		public static void switchToFrame()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//frame[@name='mainpanel']")));
        }

		public static string TakeScreenshotAtEndOfTest(string screenshotName)
		{
			string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
			var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
			DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
			string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Defect_Screenshots\\" +screenshotName + ".png";
			string localpath = new Uri(finalpth).LocalPath;
			
			Screenshot ss= ((ITakesScreenshot)driver).GetScreenshot();
			ss.SaveAsFile(localpath);
			return localpath;
	}

	public static IWebElement getPageDescriptor(string elementName, string pageName)
	{
		switch (pageName)
		{
			case "login":
				LoginPage loginPage = new LoginPage(elementName);
				element = driver.FindElement(loginPage.elementIdentifier);
				break;
			case "home":
				HomePage homePage = new HomePage(elementName);
				element = driver.FindElement(homePage.elementIdentifier);
				break;
		}

		return element;
	}
}
}
