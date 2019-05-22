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
    public class Rexnord : BasePage
    {

        public Rexnord(TestEnvironment testEnv) : base(testEnv)
        {
            //other stuff here
        }

        public QuickOrder DoQuickOrder()
        {
            FindElement(By.LinkText("Quick Order")).Click();
            WaitUtil.WaitForPageLoad(driver);
            return new QuickOrder(testEnv);
        }
    }
}
