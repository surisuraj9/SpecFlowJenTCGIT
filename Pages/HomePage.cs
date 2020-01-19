using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowJenTCGIT.Pages
{
    public class HomePage
    {
		public By elementIdentifier;
		public HomePage(String elementName)
		{
			switch (elementName)
			{
				case "title":
					this.elementIdentifier = By.TagName("title");
					break;
				case "userNameLabel":
					this.elementIdentifier = By.XPath("//td[contains(text(),'User: padmanabhuni suraj')]");
					break;
				case "contactsLink":
					this.elementIdentifier = By.XPath("//a[contains(text(),'Contacts')]");
					break;
				case "dealsLink":
					this.elementIdentifier = By.XPath("//a[contains(text(),'Deals')]");
					break;
				case "tasksLink":
					this.elementIdentifier = By.XPath("//a[contains(text(),'Tasks')]");
					break;
			}

		}
	}
}
