﻿using System;
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
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/typos");
        }

        [Test]
        public void Typos_CheckSpelling()
        {            
            var text = ChromeDriver.FindElement(By.XPath($"//p[2]"));
            var textActual = text.Text;

            var expectedText = "Sometimes you'll see a typo, other times you won't.";

            Assert.That(textActual, Is.EqualTo(expectedText));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

