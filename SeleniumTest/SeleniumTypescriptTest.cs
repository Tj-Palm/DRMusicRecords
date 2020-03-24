using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestClass]
    public class SeleniumTypescriptTest
    {

        private static string driveFolder = "C:\\Users\\Daniel\\Desktop\\SeleniumDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _driver = new ChromeDriver(driveFolder);
        }

        [TestMethod]
        public void TestClickFirstButton()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Coding Template", title);

            IWebElement ClickShowButton = _driver.FindElement(By.Id("ShowElements"));
            ClickShowButton.Click();
            IWebElement GetAllElement = _driver.FindElement(By.Id("content"));

        }
    }
}