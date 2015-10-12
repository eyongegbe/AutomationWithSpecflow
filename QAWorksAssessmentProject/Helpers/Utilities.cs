using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using QAWorksAssessmentProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWorksAssessmentProject.Helpers
{
    public class Utilities :BasePage
    {


        public static void switchToNewWindow()
        {
            Browser.Current.SwitchTo().Window(Browser.Current.WindowHandles.Last());
        }

        public static void switchToOldWindow()
        {
            Browser.Current.SwitchTo().Window(Browser.Current.WindowHandles.First());
        }

        public static void getDefaultWindowHandle()
        {
            Browser.Current.WindowHandles.First();
        }

    }
}
