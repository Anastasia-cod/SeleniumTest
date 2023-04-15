using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class TyposTest
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void Typos_CheckSpelling()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/typos");
            var text = ChromeDriver.FindElement(By.XPath($"//p[2]"));
            var textActual = text.Text;

            Assert.That(textActual, Is.EqualTo("Sometimes you'll see a typo, other times you won't."));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

