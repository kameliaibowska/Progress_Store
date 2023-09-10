using Progress_Store.Pages;

namespace Progress_Store.Models
{
    public class YourOrderPageElements : BasePage
    {
        public YourOrderPageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => $"{Constants.StoreUrl}/your-order";

        protected IWebElement SignUpCloseButton => driver.FindElement(By.ClassName("fa-times"));

        protected IWebElement TotalPriceValue => driver.FindElement(By.ClassName("e2e-total-price"));

        protected IWebElement ShopMoreButton => driver.FindElement(By.PartialLinkText("Shop More"));

        protected IWebElement ContinueAsGuestButton => driver.FindElement(By.ClassName("e2e-continue"));
    }
}
