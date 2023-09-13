using System;
using OpenQA.Selenium.Support.UI;
using Progress_Store.Pages;
using SeleniumExtras.WaitHelpers;

namespace Progress_Store.Models
{
    public class YourOrderPageElements : BasePage
    {
        public YourOrderPageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => $"{Constants.StoreUrl}/your-order";

        protected IWebElement AcceptCookiesButton => driver.FindElement(By.Id("onetrust-accept-btn-handler"));

        protected IWebElement SignUpCloseButton => driver.FindElement(By.ClassName("fa-times"));

        protected IList<IWebElement> ProductName => driver.FindElements(By.ClassName("e2e-product-name"));

        protected IList<IWebElement> RemoveProductLinks => driver.FindElements(By.ClassName("e2e-delete-item"));

        protected IList<IWebElement> ProductsTableRows => driver.FindElements(By.CssSelector("table.table--collapse> tr"));

        protected IWebElement UnitPrice(int index)
        {
            return driver.FindElements(By.CssSelector(".e2e-price-per-license"))[index];
        }

        protected IWebElement LicenseSaving(int index)
        {
            return driver.FindElement(By.CssSelector($".e2e-item-licenses-savings:nth-child({index})"));
        }

        protected IWebElement LicensesQuantityDropdown(int index)
        {
            return driver.FindElements(By.CssSelector(".k-input"))[index];
        }

        protected IWebElement LicensesQuantityPopup()
        {
            return driver.FindElements(By.CssSelector(".k-popup"))[0];
        }

        protected IWebElement LicensesQuantitySelection(int quantity)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector($"li[index='{quantity - 1}']")));
        }

        protected IWebElement TermPrice(int index)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".e2e-price-per-license")));
            return driver.FindElements(By.CssSelector(".e2e-price-per-license"))[index + 1];
        }

        protected IWebElement MaintenanceRenewPrice(int index)
        {
            return driver.FindElements(By.CssSelector(".align-items-baseline .bold"))[index - 1];
        }

        protected IWebElement MaintenanceSaving(int index)
        {
            return driver.FindElement(By.CssSelector($".e2e-item-ms-savings:nth-child({index})"));
        }

        protected IWebElement MaintenanceQuantityDropdown(int index)
        {
            return driver.FindElements(By.CssSelector(".k-input"))[index + 1];
        }

        protected IWebElement MaintenanceQuantitySelection(int quantity)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector($"li[index='{quantity}']")));
        }

        protected IWebElement SubtotalValue(int index)
        {
            return driver.FindElement(By.CssSelector($".e2e-cart-item-subtotal:nth-child({index})"));
        }

        protected IWebElement LicensesValueLabel => driver.FindElement(By.ClassName("e2e-licenses-discounts-label"));

        protected IWebElement LicensesValue => driver.FindElement(By.ClassName("e2e-licenses-price"));

        protected IWebElement MaintenanceValueLabel => driver.FindElement(By.ClassName("e2e-ms-discounts-label"));

        protected IWebElement MaintenanceValue => driver.FindElement(By.ClassName("e2e-maintenance-price"));

        protected IWebElement TotalDiscountsValueLabel => driver.FindElement(By.ClassName("e2e-total-discounts-label"));

        protected IWebElement TotalDiscountsValue => driver.FindElement(By.ClassName("e2e-total-discounts-price"));

        protected IWebElement TotalPriceValue => driver.FindElement(By.ClassName("e2e-total-price"));

        protected IWebElement ShopMoreButton => driver.FindElement(By.PartialLinkText("Shop More"));

        protected IWebElement ContinueAsGuestButton => driver.FindElement(By.ClassName("e2e-continue"));

        protected IWebElement EmptyShoppingCartMessage => driver.FindElement(By.ClassName("e2e-empty-shopping-cart-heading"));
    }
}
