using Progress_Store.Pages;
using TechTalk.SpecFlow;

namespace Progress_Store.StepDefinitions
{
    [Binding]
    public class YourOrderSteps : BaseSteps
    {
        private PurchasePage purchasePage;
        private YourOrderPage yourOrderPage;
        private int index;
        private int licenseCount;
        private string maintenanceYearsCount;

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

        [Given(@"I add products to cart")]
        public void GivenIAddProductsToCart()
        {
            AddProductsToShoppingCart();
        }

        [When(@"I select ""(.*)"" license quantities")]
        public void WhenISelectLicenseQuantities(int licenseCount)
        {
            this.index = 0;
            this.licenseCount = licenseCount;
        }

        [When(@"I select ""(.*)"" maintenance years")]
        public void WhenISelectMaintenanceYears(string maintenanceYearsCount)
        {
            this.index = 2;
            this.maintenanceYearsCount = maintenanceYearsCount;
        }

        [Then(@"Unit price is correctly updated")]
        public void ThenUnitPriceIsCorrectlyUpdated()
        {
            var unitPrice = yourOrderPage.GetUnitPrice(index);
            double discount = 0;
            yourOrderPage.ChangeLicensesQuantity(index, licenseCount);
            if (licenseCount >= 2 && licenseCount <= 5)
            {
                discount = Math.Round(unitPrice * 0.05, 2);

            }
            else if (licenseCount >= 6 && licenseCount <= 10)
            {
                discount = Math.Round(unitPrice * 0.10, 2);
            }

            var newUnitPrice = unitPrice - discount;

            // Wait for DOM update
            yourOrderPage.WaitLicenseSavingElementToBeLoaded();

            Assert.That(newUnitPrice, Is.EqualTo(yourOrderPage.GetUnitPrice(index)));

            yourOrderPage.SubtotalPrice(index, licenseCount);
            yourOrderPage.CheckLicensesTotalPrice(index);
            yourOrderPage.CheckMaintenanceTotalPrice(index);
            yourOrderPage.CheckTotalDiscountsPrice(index, licenseCount);
            yourOrderPage.CheckTotalPriceIsCorrect();
        }

        [Then(@"Term price is correctly updated")]
        public void ThenTermPriceIsCorreclyUpdated()
        {
            var renewPrice = yourOrderPage.GetMaintenanceRenewPrice(index);
            double discount = 0;
            var maintenanceCount = int.Parse(maintenanceYearsCount.Replace("+", "")
                .Replace(" year", "")
                .Replace("s", "").Trim());

            yourOrderPage.ChangeMaintenanceQuantity(index, maintenanceCount);
            if (maintenanceYearsCount == "+1 year")
            {
                discount = Math.Round(renewPrice * 0.05, 2);

            }
            else if (maintenanceYearsCount == "+2 years")
            {
                discount = Math.Round(renewPrice * 0.08, 2);
            }
            else if (maintenanceYearsCount == "+3 years")
            {
                discount = Math.Round(renewPrice * 0.11, 2);
            }
            else if (maintenanceYearsCount == "+4 years")
            {
                discount = Math.Round(renewPrice * 0.14, 2);
            }

            var newTermPrice = renewPrice - discount;

            // Wait for DOM update
            yourOrderPage.WaitMaintenanceSavingElementToBeLoaded();

            Assert.That(newTermPrice, Is.EqualTo(yourOrderPage.GetTermPrice(index)));

            yourOrderPage.SubtotalPrice(index, maintenanceCount);
            yourOrderPage.CheckMaintenanceTotalPrice(index);
            yourOrderPage.CheckMaintenanceTotalPrice(index);
            yourOrderPage.CheckTotalDiscountsPrice(index, maintenanceCount);
            yourOrderPage.CheckTotalPriceIsCorrect();
        }

        private void AddProductsToShoppingCart()
        {
            NavigateToPurchasePage();

            // add  product to shopping cart
            purchasePage.AddDevCraftCompleteToCart();
            purchasePage.WaitElementToBeLoaded();
            yourOrderPage.CloseSignUpPopUp();
            yourOrderPage.ClickShopMoreButton();

            // add other product to shopping cart
            purchasePage.AddDevCraftUIToCart();
            purchasePage.WaitElementToBeLoaded();
            yourOrderPage.CloseSignUpPopUp();
            yourOrderPage.AcceptCookies();
        }
    }
}
