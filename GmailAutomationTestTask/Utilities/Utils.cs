using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GmailAutomationTestTask.Utilities
{
    public class Utils
    {
        #region Urls

        public static string baseUrl = "https://mail.google.com/mail/u/0/#inbox";
        public static string googlePlaygroudUrl = "https://accounts.google.com/o/oauth2/v2/auth?redirect_uri=https%3A%2F%2Fdevelopers.google.com%2Foauthplayground&prompt=consent&response_type=code&client_id=407408718192.apps.googleusercontent.com&scope=https%3A%2F%2Fmail.google.com%2F&access_type=offline";
        public static string googleAccountsUrl = "https://accounts.google.com/";

        #endregion


        public Utils() {}

   
        public static String generateEmailSubject()
        {
            DateTime localDate = DateTime.Now;
           string date =   "Test " + localDate;
            return date.Substring(0, 18);

        }


        public static string genereteRandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

       


            public static void TakeScreenShot(string testName)
        {
            try
            {
                Screenshot image = ((ITakesScreenshot)PropertiesCollection.driver).GetScreenshot();
              
                string fileName = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                      @"\Screenshot" + "_" +
                      DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") +"_"+testName+ ".png");
                image.SaveAsFile(fileName);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail("Failed with Exception: " + e);
            }
        }


        public static Boolean IsAlertPresent()
        {

            bool presentFlag = false;

            try
            {
                IAlert alert = PropertiesCollection.driver.SwitchTo()
                    .Alert();
                presentFlag = true;
                alert.Accept();
            }
            catch (NoAlertPresentException ex) {}

            return presentFlag;
        }
    }
    }

