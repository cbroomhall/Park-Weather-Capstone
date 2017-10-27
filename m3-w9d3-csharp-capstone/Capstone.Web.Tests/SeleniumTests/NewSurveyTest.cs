using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Capstone.Web.Tests.PageObjects;
using OpenQA.Selenium.Chrome;

namespace Capstone.Web.Tests.SeleniumTests
{
    [TestClass]
    public class NewSurveyTest
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:55601/");
        }


        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void SeleniumNewSurveyTest()
        {
            NewSurvey entryPage = new NewSurvey(driver);
            entryPage.Navigate();

            NewSurveyResult resultPage = entryPage.FillOutForm("ChristianBigThermometer@gmail.com", "Wyoming", "Extremely Active", "Cuyahoga Valley National Park");
           
            Assert.AreEqual("Top Parks!", resultPage.Header.Text);
          

        }
    }
}
