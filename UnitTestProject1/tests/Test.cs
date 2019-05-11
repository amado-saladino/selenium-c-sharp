using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using UnitTestProject1.helper;

namespace UnitTestProject1.tests
{
    public class Test
    {
        protected IWebDriver driver;
        protected Utilities util;
        protected ExtentReports extent;
        protected ExtentTest test;
        protected ExtentTest parentTest;
        protected string path;
        protected string testName, screenshotPath;
        protected bool result;
       
        [OneTimeSetUp]
        public void Setup()
        {
            util = new Utilities();
            path = Directory.GetCurrentDirectory();
            extent = ExtentTestManager.ExtentReportInstance();
            parentTest = ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.ClassName,
                TestContext.CurrentContext.Test.Properties.Get("Description").ToString());

            driver = WebDriverFactory.Driver;
            driver.Navigate().GoToUrl(util.Url);
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void BeforeTestMethod()
        {
            testName = TestContext.CurrentContext.Test.MethodName;
            test = ExtentTestManager.CreateMethod(testName);
        }

        [TearDown]
        public void AfterMethod()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                TestContext.WriteLine(TestContext.CurrentContext.Result.FailCount + " check points failed!!");
                test.Log(Status.Fail, "One of Assertion Points Failed!");
            }                
        }

        [OneTimeTearDown]
        public void teardown()
        {
            extent.Flush();
            WebDriverFactory.CloseBrowser();
        }
    }
}
