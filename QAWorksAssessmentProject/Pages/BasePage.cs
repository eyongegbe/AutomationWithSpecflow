using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWorksAssessmentProject.Pages
{
    public class BasePage
    {

        public T As<T>() where T : BasePage
        {   
            //Casting/convert page to type or BasePage
            return (T)this;
        }

    }
}
