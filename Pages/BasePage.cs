using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Progress_Store.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        protected virtual string BaseUrl { get; }

        public void Open()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            System.Threading.Thread.Sleep(1000);
        }

        public bool IsPageOpen()
        {
            return driver.Url == BaseUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}