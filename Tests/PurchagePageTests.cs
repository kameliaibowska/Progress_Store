using OpenQA.Selenium.Support.UI;
using Progress_Store.Pages;
using SeleniumExtras.WaitHelpers;

namespace Progress_Store.Tests
{
    public class PurchagePageTests : HomeTest, Constants
    {
        private PurchasePage purchasePage;
        private YourOrderPage yourOrderPage;

        [SetUp]
        public void Setup()
        {
            purchasePage = new PurchasePage(driver);
            yourOrderPage = new YourOrderPage(driver);
            NavigateToPurchasePage();
        }

        [Test]
        public void AddItemToCart()
        {
            purchasePage.AddDevCraftCompleteToCart();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("loader-content")));

            Assert.That(yourOrderPage.IsPageOpen(), Is.True,
                Constants.PageNotFound);
        }

        private void NavigateToPurchasePage()
        {
            homePage.AcceptCookies();
            homePage.NavigateToPurchasePage();
        }
    }
}
