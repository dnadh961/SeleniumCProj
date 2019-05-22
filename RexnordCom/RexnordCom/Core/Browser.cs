using OpenQA.Selenium;
using RexnordCom.Pages;
using RexnordCom.Utils;
using System.Configuration;

namespace RexnordCom.Core
{
    public class Browser
    {
        private TestEnvironment testEnv;
        private IWebDriver driver;

        private static string SIGN_IN_LINK = "Sign In/Register";
        private static string USER_NAME_ID = "SignInInfo_UserName";
        private static string PASSWORD_ID = "SignInInfo_Password";

        public Browser(TestEnvironment testEnv)
        {
            this.testEnv = testEnv;
            driver = testEnv.GetDriver();
        }

        public void Open()
        {
            string url = ConfigurationManager.AppSettings.Get("url");
            Open(url);
        }

        public void Open(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            driver.Close();
        }

        public Rexnord Login()
        {
            string user = ConfigurationManager.AppSettings.Get("user");
            string pwd = ConfigurationManager.AppSettings.Get("pwd");
            return Login(user, pwd);
        }

        public Rexnord Login(string user, string pwd)
        {
            driver.FindElement(By.LinkText(SIGN_IN_LINK)).Click();
            driver.FindElement(By.Id(USER_NAME_ID)).SendKeys(user);
            driver.FindElement(By.Id(PASSWORD_ID)).SendKeys(pwd);
            driver.FindElement(By.Id("userNamePasswordSignInButton")).Click();
            //WaitUtil.WaitForElementPresence(driver, By.LinkText("My Account"));
            WaitUtil.WaitForPageLoad(driver);
            return new Rexnord(testEnv);
        }

        public void Logout()
        {

        }


    }
}
