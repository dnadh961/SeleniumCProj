using OpenQA.Selenium;
using RexnordCom.Core;
using RexnordCom.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RexnordCom.Pages
{
    public class BasePage
    {
        protected TestEnvironment testEnv;
        protected IWebDriver driver;

        public BasePage(TestEnvironment testEnv)
        {
            this.testEnv = testEnv;
            driver = testEnv.GetDriver();
        }

        protected IWebElement FindElement(By by)
        {
            WaitUtil.WaitForElementPresence(driver, by);
            return driver.FindElement(by);
        }
    }
}
