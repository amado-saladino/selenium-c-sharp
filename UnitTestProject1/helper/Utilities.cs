using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.helper
{
    public class Utilities
    {
        private string url;
        private string product_keyword, productName;
        NameValueCollection appSettings;

        public Utilities()
        {
            appSettings = ConfigurationManager.AppSettings;
            Url = appSettings["url"];
        }

        public void takeSnapshot(IWebDriver driver, string filename)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(filename);
        }

        public string GenerateScreenshotFileName(string path, string screenshotName)
        {
            return path + @"\Report\images\" + screenshotName + generateLocalTimeFingerprint() + ".png";
        }

        private string generateLocalTimeFingerprint()
        {
            return DateTime.Now.ToLocalTime().ToString().Replace('/', '-').Replace(':', '_');
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Productkeyword
        {
            get
            {
                product_keyword = appSettings["productkeyword"];
                return product_keyword;
            }
        }

        public string ProductName
        {
            get
            {
                productName = appSettings["productname"];
                return productName;
            }
        }
    }
}
