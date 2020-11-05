using System;
using GmailAutomationTestTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;


namespace GmailAutomationTestTask.WebPages
{
    public class LoginPage
    {
        #region Elements

        public LoginPage(IWebDriver driver) {}

        public IWebElement email => PropertiesCollection.driver.FindElement(By.Name("identifier"));

        public IWebElement nextToPasswordButton => PropertiesCollection.driver.FindElement(By.Id("identifierNext"));

        public  IWebElement password => PropertiesCollection.driver.FindElement(By.Name("password"));

        public  IWebElement nextToMailBoxButton => PropertiesCollection.driver.FindElement(By.Id("passwordNext"));

        public IWebElement profileIdentifierEmail => PropertiesCollection.driver.FindElement(By.Id("profileIdentifier"));

        #endregion


        public void LogInToGmail(string userEmail, string userPassword, string baseUrl)
        {
            PropertiesCollection.driver.Navigate().GoToUrl(Utils.googlePlaygroudUrl);

            email.SendKeys(userEmail);
           
            nextToPasswordButton.Click();
            Thread.Sleep(2000);

            password.SendKeys(userPassword);

            nextToMailBoxButton.Click();

            Thread.Sleep(2000);
            PropertiesCollection.driver.Navigate().GoToUrl(baseUrl);
        }
    }
}
