using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class InputsTest
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");
        }

        [Test]
        public void Inputs_CheckArrowUp()
        {           
            IWebElement inputField = ChromeDriver.FindElement(By.TagName("input"));
            inputField.SendKeys(Keys.ArrowUp);
 
            var upKeyResult = ChromeDriver.FindElement(By.TagName("input")).GetAttribute("value");

            Assert.That("1", Is.EqualTo(upKeyResult));
        }

        [Test]
        public void Inputs_CheckArrowDown()
        {
            IWebElement inputField = ChromeDriver.FindElement(By.TagName("input"));
            inputField.SendKeys(Keys.ArrowDown);
            inputField.SendKeys(Keys.ArrowDown);

            var downKeyResult = ChromeDriver.FindElement(By.TagName("input")).GetAttribute("value");

            Assert.That("-2", Is.EqualTo(downKeyResult));
        }

        [Test]
        public void Inputs_CheckArrowUpAndDown()
        {
            IWebElement inputField = ChromeDriver.FindElement(By.TagName("input"));
            inputField.SendKeys(Keys.ArrowUp);
            inputField.SendKeys(Keys.ArrowUp);
            inputField.SendKeys(Keys.ArrowUp);
            inputField.SendKeys(Keys.ArrowUp);
            inputField.SendKeys(Keys.ArrowDown);

            var upAndDownKeyResult = ChromeDriver.FindElement(By.TagName("input")).GetAttribute("value");

            Assert.That("3", Is.EqualTo(upAndDownKeyResult));
        }

        [Test]
        public void Inputs_CheckEnterZeroNumber()
        {
            IWebElement inputField = ChromeDriver.FindElement(By.TagName("input"));
            inputField.SendKeys("0");

            var actualResult = ChromeDriver.FindElement(By.TagName("input")).GetAttribute("value");

            Assert.That("0", Is.EqualTo(actualResult));
        }

        [Test]
        public void Inputs_CheckEnterNumber()
        {
            IWebElement inputField = ChromeDriver.FindElement(By.TagName("input"));
            inputField.SendKeys("72500");

            var actualResult = ChromeDriver.FindElement(By.TagName("input")).GetAttribute("value");

            Assert.That("72500", Is.EqualTo(actualResult));
        }

        [Test]
        public void Inputs_CheckEnterLetters()
        {
            IWebElement inputField = ChromeDriver.FindElement(By.TagName("input"));
            inputField.SendKeys("test");

            var actualResult = ChromeDriver.FindElement(By.TagName("input")).GetAttribute("value");

            Assert.IsNull(actualResult);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

