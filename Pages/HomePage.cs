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

        public string CheckPageTitle()
        {
            return HomePageTitle.Text;
        }

        public void AcceptCookies()
        {
            AcceptCookiesButton.Click();
        }

        public void NavigateToPurchasePage()
        {

            PricingLink.Click();
        }
    }
}
