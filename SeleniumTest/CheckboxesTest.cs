using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace SeleniumTest
{
    [TestFixture]

    public class CheckboxesTest
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
        }

        [Test]
        public void CheckBoxTest_GetStateFirstCheckbox_Unchecked()
        {
            IWebElement checkbox = ChromeDriver.FindElement(By.CssSelector("[type=checkbox]"));

            Assert.IsFalse(checkbox.Selected);            
        }

        [Test]
        public void CheckBoxTest_SelectFirstCheckbox()
        {
            IWebElement checkbox = ChromeDriver.FindElement(By.CssSelector("[type=checkbox]"));
            checkbox.Click();

            Assert.IsTrue(checkbox.Selected);
        }

        [Test]
        public void CheckBoxTest_GetStateSecondCheckbox_Checked()
        {
            var checkboxes = ChromeDriver.FindElements(By.TagName("input"));
            var checkedAttribute = checkboxes[1].GetAttribute("checked");

            Assert.IsNotNull(checkedAttribute);
        }

        [Test]
        public void CheckBoxTest_DeselectSecondCheckbox()
        {
            var checkboxes = ChromeDriver.FindElements(By.TagName("input"));
            checkboxes[1].Click();

            var checkedAttribute = checkboxes[1].GetAttribute("checked");

            Assert.IsNull(checkedAttribute);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}


