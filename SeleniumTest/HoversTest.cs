using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class HoversTest
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
        public void Hovers_CheckFirstUser()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/hovers");

            Actions action = new Actions(ChromeDriver);
            var firstUser = ChromeDriver.FindElement(By.ClassName("figure"));
            action.MoveToElement(firstUser).Build().Perform();

            IWebElement firstUserName = ChromeDriver.FindElement(By.XPath("//h5[text()='name: user1']"));
            IWebElement linkFirstUser = ChromeDriver.FindElement(By.XPath("//h5[text()='name: user1']/following-sibling::a"));
            Assert.IsTrue(firstUserName.Displayed);

            linkFirstUser.Click();
            IWebElement verifyPage = ChromeDriver.FindElement(By.TagName("h1"));
            var actualInfo = verifyPage.Text;

            Assert.That(actualInfo, Is.Not.EqualTo("Not Found"));
        }

        [Test]
        public void Hovers_CheckSecondUser()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/hovers");

            Actions action = new Actions(ChromeDriver);
            var allUser = ChromeDriver.FindElements(By.ClassName("figure"));
            var secondUser = allUser[1];
            action.MoveToElement(secondUser).Build().Perform();

            IWebElement secondUserName = ChromeDriver.FindElement(By.XPath("//h5[text()='name: user2']"));
            IWebElement linkSecondUser = ChromeDriver.FindElement(By.XPath("//h5[text()='name: user2']/following-sibling::a"));
            Assert.IsTrue(secondUserName.Displayed);

            linkSecondUser.Click();
            IWebElement verifyPage = ChromeDriver.FindElement(By.TagName("h1"));
            var actualInfo = verifyPage.Text;

            Assert.That(actualInfo, Is.Not.EqualTo("Not Found"));
        }

        [Test]
        public void Hovers_CheckThirdUser()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/hovers");

            Actions action = new Actions(ChromeDriver);
            var allUser = ChromeDriver.FindElements(By.ClassName("figure"));
            var thirdUser = allUser[2];
            action.MoveToElement(thirdUser).Build().Perform();

            IWebElement thirdUserName = ChromeDriver.FindElement(By.XPath("//h5[text()='name: user2']"));
            IWebElement linkThirdUser = ChromeDriver.FindElement(By.XPath("//h5[text()='name: user2']/following-sibling::a"));
            Assert.IsTrue(thirdUserName.Displayed);

            linkThirdUser.Click();
            IWebElement verifyPage = ChromeDriver.FindElement(By.TagName("h1"));
            var actualInfo = verifyPage.Text;

            Assert.That(actualInfo, Is.Not.EqualTo("Not Found"));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

