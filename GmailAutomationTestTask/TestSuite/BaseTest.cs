using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using GmailAutomationTestTask.Utilities;
namespace GmailAutomationTestTask
{
    public class BaseTest
    {
        public BaseTest()
        {
        }

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Quit();
        }

    }
}
