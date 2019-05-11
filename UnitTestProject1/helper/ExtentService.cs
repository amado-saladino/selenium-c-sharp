using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.IO;

namespace UnitTestProject1.helper
{
    public class ExtentService
    {
        private static readonly Lazy<ExtentReports> _lazy =
            new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentService()
        {
            var reporter = new ExtentHtmlReporter(Directory.GetCurrentDirectory() + @"\Report\");
            reporter.Config.Theme = Theme.Standard;
            Instance.AttachReporter(reporter);
        }

        private ExtentService()
        {
        }
    }
}