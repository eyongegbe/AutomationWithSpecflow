using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using QAWorksAssessmentProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWorksAssessmentProject.Pages
{
    class ContactUsPage : BasePage
    {

        public ContactUsPage()
        {
            PageFactory.InitElements(Browser.Current, this);
        }


        [FindsBy(How = How.CssSelector, Using = "#ctl00_MainContent_NameBox")]
        public IWebElement nameField;

        [FindsBy(How = How.CssSelector, Using = "#ctl00_MainContent_EmailBox")]
        public IWebElement emailField;

        [FindsBy(How = How.CssSelector, Using = "#ctl00_MainContent_MessageBox")]
        public IWebElement messageField;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_SendButton")]
        public IWebElement sendButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_revEmailAddress")]
        public IWebElement emailErrorMsg;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_rfvName")]
        public IWebElement nameErrorMsg;

        [FindsBy(How = How.Id, Using = "ContactHead")]
        public IWebElement contactHead;



        public void isContactUsPage()
        {
            if (sendButton.Displayed == true)
                Console.WriteLine("ContactUs Page");
            else
            {
                Console.WriteLine("Failed to Load Page");
                throw new NoSuchElementException();
            }
        }

        public void CompleteFormWithValidDetails(string name, string email, string message)
        {
            nameField.SendKeys(name);
            emailField.SendKeys(email);
            messageField.SendKeys(message);
            sendButton.Submit();
        }

        public void EnterInvalidEmail(string inValidEmail)
        {
            emailField.SendKeys(inValidEmail);
        }

        public string InvalidEmailErrorMessage()
        {
            return emailErrorMsg.Text;
        }

        public IWebElement InvalidEmailErrorMessageDisplayed()
        {
            return emailErrorMsg;
        }

        public IWebElement NoNameErrorMessageDisplayed()
        {
            return nameErrorMsg;
        }

        public void EnterName(string name)
        {
            nameField.SendKeys(name);
        }

        public void EnterEmail(string email)
        {
            emailField.SendKeys(email);
        }

        public void EnterMessage(string message)
        {
            messageField.SendKeys(message);
        }


        public void ClickSend()
        {
            sendButton.Click();
        }

        public string IncompleteErrorMessage(string errorMsg)
        {
            var message = Browser.Current.FindElement(By.CssSelector(errorMsg));
            return message.Text;
        }


        public void ClickOutSideForm()
        {   

            contactHead.Click();
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

        }
    }
}
