using System;
using OpenQA.Selenium.Support.UI;
using Progress_Store.Models;
using SeleniumExtras.WaitHelpers;

namespace Progress_Store.Pages
{
    public class YourOrderPage : YourOrderPageElements
    {
        public YourOrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void CloseSignUpPopUp()
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

        public void RemoveProductsFromShoppingCart()
        {
            foreach (var removeLink in RemoveProductLinks)
            {
                removeLink.Click();
            }
        }

        public bool ShoppingCartIsEmpty()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(
                EmptyShoppingCartMessage, Constants.EmptyShoppingCart));
            return EmptyShoppingCartMessage.Displayed;
        }

        public double GetUnitPrice(int index)
        {
            var unitPrice = UnitPrice(index).Text.Replace("$", "").Trim();
            return double.Parse(unitPrice);
        }

        public void ChangeLicensesQuantity(int index, int quantity)
        {
            LicensesQuantityDropdown(index).Click();
            var licenseQuantityPopup = LicensesQuantitySelection(quantity);
            licenseQuantityPopup.Click();
        }

        public void ChangeMaintenanceQuantity(int index, int maintenanceCount)
        {
            MaintenanceQuantityDropdown(index).Click();
            var maintenanceQuantityPopup = MaintenanceQuantitySelection(maintenanceCount);
            maintenanceQuantityPopup.Click();
        }

        public double GetTermPrice(int index)
        {
            if (TermPrice(index).Text != "Included")
            {
                var termPrice = TermPrice(index).Text.Replace("$", "").Trim();
                return double.Parse(termPrice);
            }
            else { return 0; }
        }

        public double GetMaintenanceRenewPrice(int index)
        {
            var termPrice = MaintenanceRenewPrice(index).Text.Replace("$", "").Trim();
            return double.Parse(termPrice);
        }

        public double SubtotalPrice(int index, int quantity)
        {
            var subtotalPrice = GetUnitPrice(index) * quantity + GetTermPrice(index);
            return Math.Round(subtotalPrice, 2);
        }

        public bool CheckLicensesTotalPrice(int index)
        {
            double licenses = 0;
            foreach (var tableRows in ProductsTableRows)
            {
                licenses += GetUnitPrice(index);
            }
            return licenses == GetLicensesPrice();
        }

        public bool CheckMaintenanceTotalPrice(int index)
        {
            double maintenance = 0;
            foreach (var tableRows in ProductsTableRows)
            {
                maintenance += GetTermPrice(index);
            }
            return maintenance == GetMaintenancePrice();
        }

        public bool CheckTotalDiscountsPrice(int index, int quantity)
        {
            double discounts = 0;
            foreach (var tableRows in ProductsTableRows)
            {
                discounts += GetTotalSavingsValue(index, quantity);
            }
            return discounts == GetTotalDiscountPrice();
        }

        public bool CheckTotalPriceIsCorrect()
        {
            var totalPrice = GetLicensesPrice() + GetMaintenancePrice() + GetTotalDiscountPrice();
            return totalPrice == GetTotalPrice();
        }

        public void WaitLicenseSavingElementToBeLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("e2e-item-licenses-savings")));
        }

        public void WaitMaintenanceSavingElementToBeLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("e2e-item-ms-savings")));
        }

        public void AcceptCookies()
        {
            AcceptCookiesButton.Click();
        }

        private double GetLicenseSaving(int index)
        {
            if (DoesElementExist(driver, By.ClassName("e2e-item-licenses-savings")))
            {
                var licenseSavingValue = LicenseSaving(index).Text.Replace("Save $", "").Trim();
                return double.Parse(licenseSavingValue);
            }
            else { return 0; }
        }

        private double GetMaintenancePrice()
        {
            if (DoesElementExist(driver, By.ClassName("e2e-maintenance-price")))
            {
                var maintenanceValue = MaintenanceValue.Text.Replace("$", "").Trim();
                return double.Parse(maintenanceValue);
            }
            else { return 0; }
        }

        private double GetTotalDiscountPrice()
        {
            if (DoesElementExist(driver, By.ClassName("e2e-total-discounts-price")))
            {
                var totalDiscountValue = TotalDiscountsValue.Text.Replace("- $", "-").Trim();
                return double.Parse(totalDiscountValue);
            }
            else { return 0; }
        }

        private double GetTotalSavingsValue(int index, int quantity)
        {
            var totalSavingsValue = GetLicenseSaving(index) * quantity + GetMaintenanceSaving(index) * quantity;
            return Math.Round(totalSavingsValue, 2);
        }

        private double GetMaintenanceSaving(int index)
        {
            if (DoesElementExist(driver, By.ClassName("e2e-item-ms-savings")))
            {
                var maintenanceSavingValue = MaintenanceSaving(index).Text.Replace("Save $", "").Trim();
                return double.Parse(maintenanceSavingValue);
            }
            else { return 0; }
        }

        private double GetLicensesPrice()
        {
            var licensesValue = LicensesValue.Text.Replace("$", "").Trim();
            return double.Parse(licensesValue);
        }

        private double GetTotalPrice()
        {
            var totalValue = TotalPriceValue.Text.Replace("US $", "").Trim();
            return double.Parse(totalValue);
        }
    }
}
