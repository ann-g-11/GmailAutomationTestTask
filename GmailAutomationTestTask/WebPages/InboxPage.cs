using System;
using GmailAutomationTestTask.Utilities;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic;

namespace GmailAutomationTestTask.WebPages
{
    public class InboxPage
    {
        #region Elements

        public IWebElement composeEmailBtn => PropertiesCollection.driver
       .FindElement(By.XPath("//div[text()='Написать']"));

        public IWebElement emailToFld => PropertiesCollection.driver
       .FindElement(By.XPath("//textarea[@name='to']"));

        public IWebElement emailSubjectFld => PropertiesCollection.driver
       .FindElement(By.XPath("//input[@name='subjectbox']"));

        public IWebElement emailBodyFld => PropertiesCollection.driver
       .FindElement(By.XPath("//div[@class='Am Al editable LW-avf tS-tW']"));

        public IWebElement sendEmailBtn => PropertiesCollection.driver
       .FindElement(By.XPath("//div[text()='Отправить']"));

        public String emailIsSentMessage = "//*[contains(text(),'Письмо отправлено')]";

        public String emailIsDeleteMessage = "//*[contains(text(),'Цепочка помещена в корзину.')]";

        public IWebElement deleteEmailBtn => PropertiesCollection.driver
       .FindElement(By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']"));

        public IWebElement accountBtn => PropertiesCollection.driver
       .FindElement(By.XPath("//a[@class = 'gb_D gb_Ra gb_i']"));

        public IWebElement logOutBtn => PropertiesCollection.driver
       .FindElement(By.Id("gb_71"));

        public IList<IWebElement> emailList = PropertiesCollection.driver.FindElements(By.XPath("//div[@class = 'y6']/span"));

        #endregion

        public InboxPage(IWebDriver driver) { }


        public void SendEmail(string emailTo, string emailSubject, string emailBody)
        {
            composeEmailBtn.Click();
            Thread.Sleep(8000);
            emailToFld.SendKeys(emailTo);
            emailSubjectFld.SendKeys(emailSubject);
            emailBodyFld.SendKeys(emailBody);
            sendEmailBtn.Click();

        }
        /*
        public void OpenEmailWithSubject(string emailSubject)
        {
            foreach (IWebElement emailSub in emailList)
            {
                if (emailSub.Text.Equals (emailSubject) == true)
                {
                    int index = emailList.IndexOf(emailSub);
                    Console.WriteLine(index);
                    emailSub.Click();
                    break;
                }
            }
        }
        */

        public Boolean checkThatEmailIsPresent(string emailSubject)
        {
            IList<IWebElement> emailList = PropertiesCollection.driver.FindElements(By.XPath("//div[@class = 'y6']/span"));
            bool result=false;

            for (int i = 0; i < emailList.Count; i++)
            {
                if (emailList[i].Text.Equals(emailSubject) == true)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(" Email with subject " + emailSubject + " is present");
                    result = true;
                }
               // else result = false;

            }return result;
        }

      

        public void SelectEmailCheckbox(int emailIndex)
        {
            if (emailIndex < 0)
            {
                Console.Write(" Email is not present in the list ");
            }

            IWebElement selectCheckbox = PropertiesCollection.driver.FindElements(By.XPath("//*[@role='checkbox']"))[emailIndex];
            selectCheckbox.Click();
            Thread.Sleep(5000);
        }



        public int GetIndexDeleteEmail(string emailSubject)
        {
                IList<IWebElement> emailList = PropertiesCollection.driver.FindElements(By.XPath("//div[@class = 'y6']/span"));

                Console.Write(emailList.Count.ToString());
               int result = -1;

                for (int i = 0; i < emailList.Count; i++)
                {
                    if (emailList[i].Text.Equals(emailSubject) == true)
                    {
                        Console.WriteLine("Email with subject " + emailSubject + " is present");
                        result = i+1;
                    }
                }
                return result;
            }


        public void DeleteSelectedEmailFromTheList(string emailSubject)
        {
            SelectEmailCheckbox(GetIndexDeleteEmail(emailSubject));
            deleteEmailBtn.Click();
        }


        public void LogOut()
        {
            accountBtn.Click();
            logOutBtn.Click();
            Utils.IsAlertPresent();
        }

    }
}
