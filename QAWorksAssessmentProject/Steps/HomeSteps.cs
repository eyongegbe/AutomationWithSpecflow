using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using NUnit.Framework;
using OpenQA.Selenium;
using QAWorksAssessmentProject.Pages;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace QAWorksAssessmentProject.Steps
{
    [Binding]
    public class HomeSteps
    {

        [Given(@"I am on the QAWorks homepage")]
        public void GivenIAmOnTheQAWorksHomepage()
        {
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            PropertiesCollection.currentPage = new HomePage();
        }
        
        [When(@"I click on Contact")]
        public void WhenIClickOnContact()
        {
            PropertiesCollection.currentPage = PropertiesCollection.currentPage.As<HomePage>().ClickContactTab();
        }
        
        [Then(@"I should navigate to ContactUs page")]
        public void ThenIShouldNavigateToContactUsPage()
        {
            PropertiesCollection.currentPage.As<ContactUsPage>().isContactUsPage();
        }


    }
}
