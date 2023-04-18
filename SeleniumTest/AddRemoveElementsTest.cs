using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class AddRemoveElementsTests
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
        }

        [Test]
        public void CheckCountOfAddedElements()
        {
            IWebElement addElement = ChromeDriver.FindElement(By.XPath("//button[text()='Add Element']"));
            addElement.Click();
            addElement.Click();

            IWebElement removeElement = ChromeDriver.FindElement(By.XPath("//button[text()='Delete']"));
            removeElement.Click();

            var addedElement = ChromeDriver.FindElements(By.ClassName("added-manually"));

            var actualCount = addedElement.Count();
            var expectedCount = 1;

            Assert.That(actualCount, Is.EqualTo(expectedCount), $"Actual added elements: {actualCount}, Expected added elements: {expectedCount}");           
        }
        
        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }   
    }
}

