using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace UnitTestProject1.helper
{
    public class WebDriverFactory
    {
        private WebDriverFactory() { }

        private static readonly object Obj = new object();
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null) _driver = new FirefoxDriver();

                return _driver;
            }
        }

        public static void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
            _driver = null;
        }
    }
}