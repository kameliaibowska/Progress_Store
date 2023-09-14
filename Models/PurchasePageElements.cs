using Progress_Store.Pages;

namespace Progress_Store.Models
{
    public class PurchasePageElements : BasePage
    {
        public PurchasePageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => $"{Constants.BaseUrl}/purchase.aspx?filter=web";

        protected IWebElement DevCraftUIBuyNowButton => driver.FindElement(By.XPath("(//a[contains(.,'Buy now')])[1]"));

        protected IWebElement DevCraftCompleteBuyNowButton => driver.FindElement(By.XPath("(//a[contains(.,'Buy now')])[2]"));
    }
}
