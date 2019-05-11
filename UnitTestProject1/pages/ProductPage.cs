using OpenQA.Selenium;
using System;

namespace demoqa.pages
{
    public class ProductPage : Page
    {
        By PageTitle = By.CssSelector("h1.page-title");
        By ProductTitle = By.CssSelector("h1.product_title.entry-title");
        By ProductBreadCrumb = By.CssSelector("span.post.post-product.current-item");

        public ProductPage() : base()
        {
        }

        public bool isValidPage(string product)
        {
            WaitForPageLoad();
            Console.WriteLine("Page title: " + WaitForElement(PageTitle).Text + " - " + product.ToUpper());
            Console.WriteLine("Product title: " + WaitForElement(ProductTitle).Text + " - " + product.ToUpper());
            Console.WriteLine("Product breadcrumb: " + WaitForElement(ProductBreadCrumb).Text + " - " + product);

            return WaitForElement(PageTitle).Text == product.ToUpper() &&
                WaitForElement(ProductTitle).Text == product.ToUpper() &&
                WaitForElement(ProductBreadCrumb).Text == product;
        }
    }
}
