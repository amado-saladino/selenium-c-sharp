using System;
using NUnit.Framework;
using UnitTestProject1.tests;
using demoqa.pages;
using AventStack.ExtentReports;
using System.Collections.Generic;
using UnitTestProject1.helper;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections;
using System.Threading;

namespace UnitTestProject1
{
    [TestFixture, Property("Description","User can search")]
    public class SearchProductTest : Test
    {
        [TestCaseSource("data"), Property("Description", "It should search for the product")]
        public void SearchProduct(string keyword, string productName)
        {
            screenshotPath = util.GenerateScreenshotFileName(path, testName);            
            HomePage homePage = new HomePage(driver);
            test.Log(Status.Info, "Product Name: " + productName.ToUpper());
            ProductPage productPage = homePage.Search(keyword);
            util.takeSnapshot(driver, screenshotPath);
            test.AddScreenCaptureFromPath(screenshotPath);            
            result = productPage.isValidPage(productName);
            Assert.IsTrue(result);
        }

        [Test, Property("Description", "Test 2 method description")]
        public void test2()
        {
            test.Log(Status.Info, "This is only a logging info to Test 2 method");
            TestContext.WriteLine("This is Test 2");
        }

        private static IEnumerable<TestCaseData> data()
        {
            foreach (var product in DataFactory.GetData("data.json", "products"))
            {
                yield return new TestCaseData(product["keyword"].ToString(), product["name"].ToString());
            }
        }
    }
}
