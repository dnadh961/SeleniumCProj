using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RexnordCom.Core
{
    public class ScriptExecutor
    {
        private TestEnvironment testEnv;
        private IWebDriver driver;
        private IJavaScriptExecutor jsExecutor;

        public ScriptExecutor(TestEnvironment testEnv)
        {
            this.testEnv = testEnv;
            driver = testEnv.GetDriver();
            jsExecutor = driver as IJavaScriptExecutor;
        }

        public void Click(IWebElement elmt)
        {
            jsExecutor.ExecuteScript("arguments[0].click();", elmt);
        }

        public void Clear(IWebElement elmt)
        {
            jsExecutor.ExecuteScript("arguments[0].clear();", elmt);
        }
    }
}
