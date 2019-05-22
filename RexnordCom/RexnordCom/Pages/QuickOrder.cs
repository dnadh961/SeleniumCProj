using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RexnordCom.Core;
using OpenQA.Selenium;
using RexnordCom.Utils;

namespace RexnordCom.Pages
{
    public class QuickOrder : BasePage
    {
        public QuickOrder(TestEnvironment testEnv) : base(testEnv)
        {
        }

        public void EnterPartNumber(String part, int index)
        {
            FindElement(By.Name("itemName_" + (index - 1))).SendKeys(part);
        }

        public void EnterQuantity(string qty, int index)
        {
            IWebElement qtyElmt = FindElement(By.Name("itemQty_" + (index - 1)));
            qtyElmt.Clear();
            qtyElmt.SendKeys(qty);
        }

        public ShoppingCart DoQuickAddToCart()
        {
            //FindElement(By.Id("quickOrderViewAddAllToCartAndCheckOutButton")).Click();
            IWebElement quickAddToCartBtn = FindElement(By.Id("quickOrderViewAddAllToCartAndCheckOutButton"));
            testEnv.GetScriptExecutor().Click(quickAddToCartBtn);
            WaitUtil.WaitForElementPresence(driver, By.XPath("//h1[text()='Shopping Cart']"));
            return new ShoppingCart(testEnv);
        }
    }
}
