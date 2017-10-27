using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Tests.PageObjects
{
    class NewSurveyResult : BasePage
    {
        public NewSurveyResult(IWebDriver driver)
            : base(driver, "/Home/Surveys")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "button")]
        public IWebElement Header { get; set; }



    }
}
