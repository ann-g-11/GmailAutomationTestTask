using System;
using GmailAutomationTestTask.Utilities;


namespace GmailAutomationTestTask.WebPages
{
    public static class Pages
    {

        public static LoginPage loginPage = new LoginPage(PropertiesCollection.driver);
        public static InboxPage inboxPage = new InboxPage(PropertiesCollection.driver);


    }
}