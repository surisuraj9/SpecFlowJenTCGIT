using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowJenTCGIT.Pages
{
    public class LoginPage
    {
		public By elementIdentifier;
		public LoginPage(string elementName)
		{
			switch (elementName)
			{
				case "username":
					this.elementIdentifier = By.Name("username");
					break;
				case "password":
					this.elementIdentifier = By.Name("password");
					break;
				case "login_button":
					this.elementIdentifier = By.XPath("//input[@value='Login']");
					break;
				case "signUpBtn":
					this.elementIdentifier = By.LinkText("Sign Up");
					break;
				case "crmLogo":
					this.elementIdentifier = By.XPath("//a[@class='navbar-brand']//img[@class='img-responsive']");
					break;
			}
		}
	}
}
