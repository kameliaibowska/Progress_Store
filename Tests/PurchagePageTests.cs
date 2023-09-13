using Progress_Store.Pages;

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
            purchasePage.WaitElementToBeLoaded();

            Assert.That(yourOrderPage.IsPageOpen(), Is.True,
                Constants.PageNotFound);
            yourOrderPage.AcceptCookies();
        }

        private void NavigateToPurchasePage()
        {
            homePage.AcceptCookies();
            homePage.NavigateToPurchasePage();
        }
    }
}
