using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecFlowJenTCGIT.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowJenTCGIT.Base
{
    public class TestBase
    {
		public TestBase()
		{
			Console.WriteLine("In test Base class constructor");
		}
        public static IWebDriver driver;
        public static void initialization()
        {
            string browserName= ConfigurationManager.AppSettings["browser"];
			if (browserName.Equals("FF", StringComparison.InvariantCultureIgnoreCase))
				driver = new FirefoxDriver();
			if (browserName.Equals("CHROME", StringComparison.InvariantCultureIgnoreCase))
				driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Cookies.DeleteAllCookies();
			driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(TestUtil.PAGE_LOAD_TIMEOUT);
			driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(TestUtil.IMPLICIT_WAIT);
		}
    }
}
