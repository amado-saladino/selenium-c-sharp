using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject1.helper;

namespace demoqa.pages
{
    public class Page
    {
        protected IWebDriver driver;
        WebDriverWait wait;
        By SearchButton = By.ClassName("noo-search");
        By SearchInput = By.Name("s");
        By SearchCanvas = By.ClassName("remove-form");
        ProductPage ProductPage;

        public Page()
        {
            this.driver = WebDriverFactory.Driver;
            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(15));
        }

        protected IWebElement WaitForElement(By element)
        {
           return wait.Until<IWebElement>((driver)=>driver.FindElement(element));
        }

        protected void WaitForPageLoad()
        {            
            wait.Until(driver=>((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void WaitForCondition(Func<IWebDriver,bool> condtition)
        {
            wait.Until<bool>(condtition);
        }

        public ProductPage Search(string keyword)
        {
            driver.FindElement(SearchButton).Click();
            WaitForElement(SearchInput).SendKeys(keyword + Keys.Enter);
            WaitForCondition(d=>!d.FindElement(SearchCanvas).Displayed);
            return ProductPage == null ? ProductPage = new ProductPage() : ProductPage;
        }
    }
}
