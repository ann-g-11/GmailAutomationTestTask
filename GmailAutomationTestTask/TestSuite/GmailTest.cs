using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using GmailAutomationTestTask.Utilities;
using GmailAutomationTestTask.WebPages;

namespace GmailAutomationTestTask
{
    [TestFixture()]
    public class GmailTest: BaseTest
    {
        string userEmail = UserInfo.userEmail;
        string userPassword = UserInfo.userPassword;
        string emailSubject = Utils.generateEmailSubject();
      
      

        WebDriverWait wait;

        [SetUp]
        public void LoginToGmail()
        {
           Pages.loginPage.LogInToGmail(userEmail, userPassword, Utils.baseUrl);
           wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
           wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            

        }

        [TestCase (TestName = "001")]
       public void CheckSendEmail()

       {            
            String emailBody = "Some body "+ Utils.genereteRandomString(11);
            Pages.inboxPage.SendEmail(userEmail, emailSubject, emailBody);
           
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .VisibilityOfAllElementsLocatedBy(By.XPath(Pages.inboxPage.emailIsSentMessage)));
            IWebElement alet = PropertiesCollection.driver.FindElement(By.XPath("//*[contains(text(),'Письмо отправлено')]"));
            Console.WriteLine(alet.Text);
            Utils.TakeScreenShot("Send_Email");
            
        }

        [TestCase(TestName = "002")]
        public void CheckThatEmailIsPresent()
         {
            
            Assert.IsTrue(Pages.inboxPage.checkThatEmailIsPresent(emailSubject));
            Utils.TakeScreenShot("Check_Email_Is_Present");
            
        }

        [TestCase(TestName = "003")]
        public void DeleteEmail()
        {            
            Pages.inboxPage.DeleteSelectedEmailFromTheList(emailSubject);
           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
               .VisibilityOfAllElementsLocatedBy(By.XPath(Pages.inboxPage.emailIsDeleteMessage)));
           IWebElement alet = PropertiesCollection.driver.FindElement(By.XPath("//*[contains(text(),'Цепочка помещена в корзину.')]"));
           Console.WriteLine(alet.Text);
           Utils.TakeScreenShot("Delete_Email");
            
        }
       
        
        [TearDown]
        public void LogOutFromGmail()
        {

            Pages.inboxPage.LogOut();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(Utils.googleAccountsUrl));

            Assert.AreEqual(Pages.loginPage.profileIdentifierEmail.Text, userEmail);
        }
       
    }
}
