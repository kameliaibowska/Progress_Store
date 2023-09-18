using Progress_Store.Pages;

namespace Progress_Store.Tests
{
    public class YourOrderPageTests : HomeTest
    {
        private PurchasePage purchasePage;
        private YourOrderPage yourOrderPage;

        [SetUp]
        public void Setup()
        {
            purchasePage = new PurchasePage(driver);
            yourOrderPage = new YourOrderPage(driver);
            AddProductsToShoppingCart();
        }

        [Test]
        public void EmptyShoppingCart()
        {
            yourOrderPage.RemoveProductsFromShoppingCart();

            Assert.That(yourOrderPage.ShoppingCartIsEmpty(), Is.True,
                Constants.ShoppingCartIsNotEmpty);
        }

        [Test]
        public void CheckCartTotalPrice()
        {
            yourOrderPage.CheckTotalPriceIsCorrect();
        }

        [TestCase(0, 3)]
        [TestCase(0, 8)]
        public void UpdateLicenseCount(int index, int licenseCount)
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

        [TestCase(2, "+1 year")]
        [TestCase(2, "+3 years")]
        public void UpdateMaintenanceCount(int index, string maintenanceYearsCount)
        {
            var renewPrice = yourOrderPage.GetMaintenanceRenewPrice(index);
            double discount = 0;
            var maintenanceCount = int.Parse(maintenanceYearsCount
                .Replace("+", "")
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
            homePage.AcceptCookies();
            homePage.NavigateToPurchasePage();
            
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
