using Progress_Store.Pages;
using TechTalk.SpecFlow;

namespace Progress_Store.StepDefinitions
{
    [Binding]
    public class PurchaseSteps : BaseSteps
    {
        private PurchasePage purchasePage;
        private YourOrderPage yourOrderPage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            purchasePage = new PurchasePage(driver);
            yourOrderPage = new YourOrderPage(driver);

            OpenHomePage();
        }

        [AfterScenario]
        public void AfterScenarioAsync()
        {
            driver.Quit();
        }

        [Given(@"I am on the home page and click on Pricing Menu")]
        public void GivenHomePageAndNavigateToPricing()
        {
            NavigateToPurchasePage();
        }

        [When(@"I click to buy product bundle")]
        public void WhenIClickToBuyProduct()
        {
            purchasePage.AddDevCraftCompleteToCart();
            purchasePage.WaitElementToBeLoaded();
        }

        [Then(@"Product is added in cart")]
        public void ThenProductIsAddedInCart()
        {
            Assert.That(yourOrderPage.IsPageOpen(), Is.True,
                Constants.PageNotFound);
            yourOrderPage.AcceptCookies();
        }
    }
}
