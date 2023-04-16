using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class SortableDataTablesTest
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
        public void TableFirst_CheckThirdRowFirstCell()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
            var thirdRowFirstCellValue = ChromeDriver.FindElement(By.XPath("//table//tr[3]//td[1]"));
            var actualValue = thirdRowFirstCellValue.Text;

            var expectedValue = "Doe";

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TableFirst_CheckSecondRowThirdCell()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
            var secondRowThirdCellValue = ChromeDriver.FindElement(By.XPath("//table//tr[2]//td[3]"));
            var actualValue = secondRowThirdCellValue.Text;

            var expectedValue = "fbach@yahoo.com";

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TableSecond_CheckFourthRowFourthCell()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
            var fourthRowfourthCellValue = ChromeDriver.FindElement(By.XPath("//table[2]//tr[4]//td[4]"));
            var actualValue = fourthRowfourthCellValue.Text;

            var expectedValue = "$50.00";

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TableSecond_CheckFirstRowFifthCell()
        {
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
            var firstRowFifthCellValue = ChromeDriver.FindElement(By.XPath("//table[2]//tr[1]//td[5]"));
            var actualValue = firstRowFifthCellValue.Text;

            var expectedValue = "http://www.jsmith.com";

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

