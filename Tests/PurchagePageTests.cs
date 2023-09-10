using Progress_Store.Pages;

namespace Progress_Store.Tests
{
    public class PurchagePageTests : HomeTest, Constants
    {
        private HomePage homePage;
        private PurchasePage purchasePage;
        private YourOrderPage yourOrderPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(driver);
            purchasePage = new PurchasePage(driver);
            yourOrderPage = new YourOrderPage(driver);
            NavigateToPurchasePage();
        }

        [Test]
        public void AddItemToCart()
        {
            //await Task.Run(async () =>
            //{
            //    await purchasePage.AddDevCraftCompleteToCartAsync();
            //});

            //Assert.That(yourOrderPage.IsPageOpen(), Is.True,
            //    Constants.PageNotFound);
        }

        private void NavigateToPurchasePage()
        {
            homePage.Open();
            homePage.AcceptCookies();
            homePage.NavigateToPurchasePage();
        }
    }
}
