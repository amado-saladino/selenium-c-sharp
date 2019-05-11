using AventStack.ExtentReports;
using NUnit.Framework;

namespace UnitTestProject1.tests
{
    [TestFixture, Property("Description","User can SecondPage")]
    public class SecondPageTest : Test
    {
        [Test, Property("Description", "Test2 method description")]
        public void Test1()
        {
            test.Log(Status.Info, "This is only a logging info to Test1 method");
            //test.Log(Status.Fail, "It should pass");
            TestContext.WriteLine("This is Test1");
            screenshotPath = util.GenerateScreenshotFileName(path, testName);
            util.takeSnapshot(driver, screenshotPath);
            test.AddScreenCaptureFromPath(screenshotPath);
        }
    }
}
