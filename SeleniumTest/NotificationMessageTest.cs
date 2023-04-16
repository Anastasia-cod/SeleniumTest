using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class NotificationMessageTest
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
        public void CheckNotificationMessage()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/notification_message_rendered");
            var linkButton = ChromeDriver.FindElement(By.CssSelector(".example a"));
            linkButton.Click();

            var message = ChromeDriver.FindElement(By.Id("flash"));
            var textMessage = message.Text;

            var expectedMessage = $"Action successful\n×";

            Assert.That(textMessage, Is.EqualTo(expectedMessage));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

