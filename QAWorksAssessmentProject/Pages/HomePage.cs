using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWorksAssessmentProject.Pages
{
    class HomePage : BasePage
    {
        public HomePage()
        {
            PageFactory.InitElements(Browser.Current, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='menu']/li[1]")]
        public IWebElement ContactTab;


        public ContactUsPage ClickContactTab()
        {
            ContactTab.Click();
            return new ContactUsPage();
        }

    }
}
