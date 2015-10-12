using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace QAWorksAssessmentProject.Pages
{
    public class PropertiesCollection
    {   
        private static BasePage _currentPage;

        public static BasePage currentPage
        {
            get { return _currentPage; }
            set
            {   //setting the value to the property(currentPage) and returning the value to the caller (_currentPage)
                ScenarioContext.Current["class"] = value;
                _currentPage = ScenarioContext.Current.Get<BasePage>("class");
            }
        }
    }
}
