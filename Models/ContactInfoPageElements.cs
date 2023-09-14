using Progress_Store.Pages;

namespace Progress_Store.Models
{
    public class ContactInfoPageElements : BasePage
    {
        public ContactInfoPageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => $"{Constants.StoreUrl}/contact-info";

        protected IWebElement BillingFirstNameField => driver.FindElement(By.Id("biFirstName"));

        protected IWebElement BillingLastNameField => driver.FindElement(By.Id("biLastName"));

        protected IWebElement BillingEmailField => driver.FindElement(By.Id("biEmail"));

        protected IWebElement BillingCompanyField => driver.FindElement(By.Id("biCompany"));

        protected IWebElement BillingPhoneField => driver.FindElement(By.Id("biPhone"));

        protected IWebElement BillingAddressField => driver.FindElement(By.Id("biAddress"));

        protected IWebElement BillingSelectCountryDropdown => driver.FindElements(By.ClassName("k-input")).First();

        protected IWebElement BillingSelectStateDropdown => driver.FindElement(By.Id("biState")).FindElement(By.ClassName("k-input"));

        protected IWebElement BillingCityField => driver.FindElement(By.Id("biCity"));

        protected IWebElement BillingZipCodeField => driver.FindElement(By.Id("biZipCode"));

        protected IWebElement BillingVatIdField => driver.FindElement(By.Id("biCountryTaxIdentificationNumber"));

        protected IWebElement BillingGSTField => driver.FindElement(By.Id("biGST"));

        protected IWebElement LicenseHolderCheckBox => driver.FindElement(By.Id("siSameAsBilling"));

        protected IWebElement LicenseHolderFirstNameField => driver.FindElement(By.Id("siFirstName"));

        protected IWebElement LicenseHolderLastNameField => driver.FindElement(By.Id("siLastName"));

        protected IWebElement LicenseHolderEmailField => driver.FindElement(By.Id("siEmail"));

        protected IWebElement LicenseHolderCompanyField => driver.FindElement(By.Id("siCompany"));

        protected IWebElement LicenseHolderAddressField => driver.FindElement(By.Id("siAddress"));

        protected IWebElement LicenseHolderSelectCountryDropdown => driver.FindElements(By.ClassName("k-input")).Last();

        protected IWebElement ErrorMessageLabel => driver.FindElement(By.ClassName("error-message"));

        protected IWebElement BackButton => driver.FindElement(By.ClassName("e2e-back"));
    }
}
