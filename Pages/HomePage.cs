using Progress_Store.Models;

namespace Progress_Store.Pages
{
    public class HomePage : HomePageElements
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
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
