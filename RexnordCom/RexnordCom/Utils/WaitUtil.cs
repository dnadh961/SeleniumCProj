using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RexnordCom.Utils
{
    class WaitUtil
    {

        private static int max_timeout = 180;
        public static void WaitForElementPresence(IWebDriver driver, By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(max_timeout)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

        public static void WaitForElementVisibility(IWebDriver driver, By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(max_timeout)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitForElementClickable(IWebDriver driver, By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(max_timeout)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitForPageLoad(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(max_timeout));
            Func<IWebDriver, bool> waitForPageLoad = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript(
                             "return document.readyState").Equals("complete");
            });
            wait.Until(waitForPageLoad);
        }

    }
}
