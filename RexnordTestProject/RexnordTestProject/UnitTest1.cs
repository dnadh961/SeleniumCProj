using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RexnordCom.Core;
using RexnordCom.Pages;

namespace RexnordTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestEnvironment testEnv = new TestEnvironment();
            Browser browser = testEnv.GetBrowser();
            browser.Open();
            Rexnord homePage = browser.Login();
            QuickOrder quickOrderPage = homePage.DoQuickOrder();
            quickOrderPage.EnterPartNumber("P3U216N", 1);
            quickOrderPage.EnterQuantity("2", 1);
            ShoppingCart cartPage = quickOrderPage.DoQuickAddToCart();
            Console.Write("");
        }
    }
}
