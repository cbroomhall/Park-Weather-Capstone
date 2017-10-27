using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Tests.PageObjects
{
    class NewSurvey : BasePage
    {
        public NewSurvey(IWebDriver driver)
            : base(driver, "/Home/NewSurvey")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "EmailAddress")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Name, Using = "State")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Name, Using = "ActivityLevel")]
        public IWebElement ActivityLevel { get; set; }

        [FindsBy(How = How.Name, Using = "ParkCode")]
        public IWebElement ParkCode { get; set; }
    
        [FindsBy(How = How.Id, Using = "button")]

        public IWebElement CalculateButton { get; set; }

        public NewSurveyResult FillOutForm (string email, string state, string activity, string parkCode)
        {
            EmailAddress.SendKeys(email.ToString());

            State.SendKeys(state.ToString());

            SelectElement activityDropDown = new SelectElement(ActivityLevel);
            activityDropDown.SelectByText(activity);

            SelectElement parkCodeDropDown = new SelectElement(ParkCode);
            parkCodeDropDown.SelectByText(parkCode);

            CalculateButton.Click();

            return new NewSurveyResult(driver);
        }


    }
}
