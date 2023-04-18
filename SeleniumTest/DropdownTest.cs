using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class DropdownTest
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
        }

        [Test]
        public void CheckExsistingAllElementsInDropdown()
        {           
            IWebElement dropdown = ChromeDriver.FindElement(By.Id("dropdown"));
            dropdown.Click();

            var elementFirstInDropdown = ChromeDriver.FindElement(By.XPath($"//option[1]"));

            Assert.IsNotNull(elementFirstInDropdown);

            var elementSecondInDropdown = ChromeDriver.FindElement(By.XPath($"//option[2]"));

            Assert.IsNotNull(elementSecondInDropdown);
        }

        [Test]
        public void SelectFirstElementInDropdown()
        {
            IWebElement dropdown = ChromeDriver.FindElement(By.Id("dropdown"));
            dropdown.Click();

            var elementFirstInDropdown = ChromeDriver.FindElement(By.TagName($"option"));
            elementFirstInDropdown.Click();

            Assert.IsTrue(elementFirstInDropdown.Selected);
        }

        [Test]
        public void SelectSecondElementInDropdown()
        {
            IWebElement dropdown = ChromeDriver.FindElement(By.Id("dropdown"));
            dropdown.Click();

            var elementSecondInDropdown = ChromeDriver.FindElement(By.XPath($"//option[2]"));
            elementSecondInDropdown.Click();

            Assert.IsTrue(elementSecondInDropdown.Selected);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

