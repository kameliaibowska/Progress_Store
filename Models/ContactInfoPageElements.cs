using Progress_Store.Pages;

namespace Progress_Store.Models
{
    public class ContactInfoPageElements : BasePage
    {
        public ContactInfoPageElements(IWebDriver driver) : base(driver)
        {
        }

        protected override string BaseUrl => $"{Constants.StoreUrl}/contact-info";

        protected IWebElement ContactInfoPageTitle => driver.FindElement(By.TagName("title"));

        protected IWebElement FirstNameField => driver.FindElement(By.Id("biFirstName"));

        protected IWebElement LastNameField => driver.FindElement(By.Id("biLastName"));

        protected IWebElement EmailField => driver.FindElement(By.Id("biEmail"));

        protected IWebElement CompanyField => driver.FindElement(By.Id("biCompany"));

        protected IWebElement PhoneField => driver.FindElement(By.Id("biPhone"));

        protected IWebElement AddressField => driver.FindElement(By.Id("biAddress"));

        protected IWebElement SelectCountryDropdown => driver.FindElement(By.ClassName("k-input"));

        protected IWebElement CityField => driver.FindElement(By.Id("biCity"));

        protected IWebElement ZipCodeField => driver.FindElement(By.Id("biZipCode"));

        protected IWebElement VatIdField => driver.FindElement(By.Id("biCountryTaxIdentificationNumber"));

        protected IWebElement LicenseHolderCheckBox => driver.FindElement(By.Id("siSameAsBilling"));

        protected IWebElement BackButton => driver.FindElement(By.ClassName("e2e-back"));

        protected IWebElement ContinueButton => driver.FindElement(By.ClassName("e2e-continue"));
    }
}
