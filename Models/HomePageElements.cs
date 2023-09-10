using Progress_Store.Pages;

namespace Progress_Store.Models
{
    public class HomePageElements : BasePage
    {
        public HomePageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => Constants.BaseUrl;

        protected IWebElement HomePageTitle => driver.FindElement(By.TagName("title"));

        protected IWebElement AcceptCookiesButton => driver.FindElement(By.Id("onetrust-accept-btn-handler"));

        protected IWebElement PricingLink => driver.FindElement(By.PartialLinkText("Pricing"));
    }
}
