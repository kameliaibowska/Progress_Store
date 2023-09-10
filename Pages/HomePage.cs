using OpenQA.Selenium.Support.UI;
using Progress_Store.Models;
using SeleniumExtras.WaitHelpers;

namespace Progress_Store.Pages
{
    public class HomePage : HomePageElements
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private WebDriverWait wait;

        public string CheckPageTitle()
        {
            return HomePageTitle.Text;
        }

        public void AcceptCookies()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var acceptCookiesButton = wait.Until(
                ExpectedConditions.ElementIsVisible(By.Id("onetrust-accept-btn-handler")));


            //await Task.Run(() =>
            //{
            acceptCookiesButton.Click();
            //});
        }

        public void NavigateToPurchasePage()
        {

            PricingLink.Click();
        }
    }
}
