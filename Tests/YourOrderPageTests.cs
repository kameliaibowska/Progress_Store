using Progress_Store.Pages;

namespace Progress_Store.Tests
{
    public class YourOrderPageTests : HomeTest, Constants
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

        [TestCase(1, 3)]
        [TestCase(1, 8)]
        public void UpdateLicenseCount(int index, int licenseCount)
        {
            var unitPrice = yourOrderPage.GetUnitPrice(index);
            double discount = 0;
            yourOrderPage.ChangeLicensesQuantity(index, licenseCount.ToString());
            if (licenseCount >= 2 && licenseCount <= 5)
            {
                discount = Math.Round(unitPrice * 0.05);

            }
            else if (licenseCount >= 6 && licenseCount <= 10)
            {
                discount = Math.Round(unitPrice * 0.10);
            }

            var newUnitPrice = unitPrice - discount;

            Assert.That(newUnitPrice, Is.EqualTo(yourOrderPage.GetUnitPrice(index)));

            yourOrderPage.SubtotalPrice(index, licenseCount);
            yourOrderPage.CheckLicensesTotalPrice(index);
            yourOrderPage.CheckMaintenanceTotalPrice(index);
            yourOrderPage.CheckTotalDiscountsPrice(index, licenseCount);
            yourOrderPage.CheckTotalPriceIsCorrect();
        }

        [TestCase(1, "+1 year")]
        [TestCase(1, "+3 years")]
        public void UpdateMaintenanceCount(int index, string maitenanceYearsCount)
        {
            var termPrice = yourOrderPage.GetTermPrice(index);
            double discount = 0;
            yourOrderPage.ChangeMaintenanceQuantity(index, maitenanceYearsCount);
            if (maitenanceYearsCount == "+1 year")
            {
                discount = Math.Round(termPrice * 0.08);

            }
            else if (maitenanceYearsCount == "+2 years")
            {
                discount = Math.Round(termPrice * 0.11);
            }
            else if (maitenanceYearsCount == "+3 years")
            {
                discount = Math.Round(termPrice * 0.14);
            }
            else if (maitenanceYearsCount == "+4 years")
            {
                discount = Math.Round(termPrice * 0.17);
            }

            var newTermPrice = termPrice - discount;

            Assert.That(newTermPrice, Is.EqualTo(yourOrderPage.GetTermPrice(index)));

            var maitenanceCount = int.Parse(maitenanceYearsCount.Replace("+", "")
                .Replace(" year", "")
                .Replace("s", "").Trim());
            yourOrderPage.SubtotalPrice(index, maitenanceCount);
            yourOrderPage.CheckMaintenanceTotalPrice(index);
            yourOrderPage.CheckMaintenanceTotalPrice(index);
            yourOrderPage.CheckTotalDiscountsPrice(index, maitenanceCount);
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
