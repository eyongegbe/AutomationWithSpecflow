using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using NUnit.Framework;
using OpenQA.Selenium;
using QAWorksAssessmentProject.Pages;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace QAWorksAssessmentProject.Steps
{
    [Binding]
    public class ContactUsSteps
    {


        [Given(@"I am on the QAWorks Staging Site")]
        public void GivenIAmOnTheQAWorksStagingSite()
        {
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Window.Maximize();
            PropertiesCollection.currentPage = new HomePage();
            PropertiesCollection.currentPage = PropertiesCollection.currentPage.As<HomePage>().ClickContactTab();
        }
        
        [Then(@"I should be able to contact QA Works with the following information")]
        public void ThenIShouldBeAbleToContactQAWorksWithTheFollowingInformation(Table table)
        {
            dynamic values = table.CreateDynamicInstance();
            PropertiesCollection.currentPage.As<ContactUsPage>().CompleteFormWithValidDetails(values.Name, values.Email, values.Message);
        }

        [Given(@"I am on the Contact Page of QAWorks Staging Site")]
        public void GivenIAmOnTheContactPageOfQAWorksStagingSite()
        {
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Window.Maximize();
            PropertiesCollection.currentPage = new HomePage();
            PropertiesCollection.currentPage = PropertiesCollection.currentPage.As<HomePage>().ClickContactTab();
        }

        [When(@"I complete the form with an invalid email address")]
        public void WhenICompleteTheFormWithAnInvalidEmailAddress(Table table)
        {
            dynamic values = table.CreateDynamicInstance();
            PropertiesCollection.currentPage.As<ContactUsPage>().EnterInvalidEmail(values.InvalidEmail);
            PropertiesCollection.currentPage.As<ContactUsPage>().EnterName(values.Name);
        }

        [Then(@"an error message should display below the email field")]
        public void ThenAnErrorMessageShouldDisplayBelowTheEmailField(Table table)
        {
            dynamic values = table.CreateDynamicInstance();
            var errorMessage = values.ErrorMsg;
            var errorMessageText = PropertiesCollection.currentPage.As<ContactUsPage>().InvalidEmailErrorMessage();
            var errorMessageDisplayed = PropertiesCollection.currentPage.As<ContactUsPage>().InvalidEmailErrorMessageDisplayed().Displayed;
            Assert.That(errorMessageDisplayed , "error message is missing");
            Assert.That(errorMessageText.Equals(errorMessage), "Wrong Error Email Message"); 
        }


        [When(@"I complete the form with incomplete information ""(.*)"", (.*), (.*)")]
        public void WhenICompleteTheFormWithIncompleteInformation(string Name, string Email, string Message)
        {
            PropertiesCollection.currentPage.As<ContactUsPage>().EnterName(Name);                    
            PropertiesCollection.currentPage.As<ContactUsPage>().EnterEmail(Email);
            PropertiesCollection.currentPage.As<ContactUsPage>().EnterMessage(Message);
        }


        [Then(@"the correct error message (.*) should be displayed correctly(.*)")]
        public void ThenTheCorrectErrorMessageShouldBeDisplayedCorrectly(string errorMsgText, string errorMsg)
        {
             PropertiesCollection.currentPage.As<ContactUsPage>().ClickOutSideForm();
             PropertiesCollection.currentPage.As<ContactUsPage>().ClickSend();
             var msg = PropertiesCollection.currentPage.As<ContactUsPage>().IncompleteErrorMessage(errorMsg);
             Assert.That(errorMsgText.Equals(msg), "Wrong Message Displayed");
        }


    }
}
