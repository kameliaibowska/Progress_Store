using Progress_Store.Pages;

namespace Progress_Store.Models
{
    public class PurchasePageElements : BasePage
    {
        public PurchasePageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => $"{Constants.BaseUrl}/purchase.aspx?filter=web";

        protected IList<IWebElement> ProductItems => driver.FindElements(By.ClassName("Pricings-button"));

        protected IWebElement DevCraftCompleteBuyNowButton => 
            driver.FindElement(By.XPath("(//a[@class='Btn Btn--prim4 u-db'])[2]"));
    }
}
