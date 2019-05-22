using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace RexnordCom.Core
{
    public class TestEnvironment
    {
        private IWebDriver driver;
        private Browser browser;
        private ScriptExecutor scriptExecutor;

        public TestEnvironment()
        {
            string browser = ConfigurationManager.AppSettings.Get("browser");
            initializeDriver(browser);
        }

        private void initializeDriver(String browser)
        {
            string driversDir = ConfigurationManager.AppSettings.Get("drivers.dir");
            if ("firefox".Equals(browser))
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@driversDir);
                driver = new FirefoxDriver(service);
            }
            else if ("chrome".Equals(browser))
            {
                driver = new ChromeDriver(@driversDir);
            }
            driver.Manage().Window.Maximize();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public Browser GetBrowser()
        {
            if (browser == null)
            {
                browser = new Browser(this);
            }
            return browser;
        }

        public ScriptExecutor GetScriptExecutor()
        {
            if(scriptExecutor == null)
            {
                scriptExecutor = new ScriptExecutor(this);
            }
            return scriptExecutor;
        }
    }
}
