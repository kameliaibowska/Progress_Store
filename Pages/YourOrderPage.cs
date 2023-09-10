using Progress_Store.Models;

namespace Progress_Store.Pages
{
    public class YourOrderPage : YourOrderPageElements
    {
        public YourOrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void CloseSigneUpPopUp()
        {
            SignUpCloseButton.Click();
        }

        public void ClickShopMoreButton()
        {
            ShopMoreButton.Click();
        }

        public void ClickContinueAsGuestButton()
        {
            ContinueAsGuestButton.Click();
        }
    }
}
