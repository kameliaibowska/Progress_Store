using Progress_Store.Models;

namespace Progress_Store.Pages
{
    public class ContactInfoPage : ContactInfoPageElements
    {
        public ContactInfoPage(IWebDriver driver) : base(driver)
        {
        }

        public void FieldOutBillingInformation(
            string firstName,
            string lastName,
            string email,
            string company,
            string phone,
            string address,
            string country,
            string city,
            string zipCode,
            string vatId)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            EmailField.SendKeys(email);
            CompanyField.SendKeys(company);
            PhoneField.SendKeys(phone);
            AddressField.SendKeys(address);
            SelectCountryDropdown.SendKeys(country);
            CityField.SendKeys(city);
            ZipCodeField.SendKeys(zipCode);
            VatIdField.SendKeys(vatId);
        }

        public async Task PressContinueButtonAsync()
        {
            await Task.Run(() =>
            {
                ContinueButton.Click();
            });
        }

        public async Task PressBackButtonAsync()
        {
            await Task.Run(() =>
            {
                BackButton.Click();
            });
        }
    }
}
