using Progress_Store.Pages;

namespace Progress_Store.Models
{
    public class ReviewOrderPageElements : BasePage
    {
        public ReviewOrderPageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => $"{Constants.StoreUrl}/review-order";

        protected IWebElement ProductsTable => driver.FindElement(By.ClassName("table--collapse"));
    }
}
