using OpenQA.Selenium.Support.UI;
using Progress_Store.Models;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace Progress_Store.Pages
{
    public class ContactInfoPage : ContactInfoPageElements
    {
        public ContactInfoPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillOutBillingInformation(
            string firstName,
            string lastName,
            string email,
            string company,
            string phone,
            string address,
            string country,
            string city,
            string zipCode)
        {
            BillingFirstNameField.SendKeys(firstName);
            BillingLastNameField.SendKeys(lastName);
            BillingEmailField.SendKeys(email + " " + Keys.Backspace);
            BillingCompanyField.SendKeys(company);
            BillingPhoneField.SendKeys(phone);
            BillingAddressField.SendKeys(address);
            BillingSelectCountryDropdown.SendKeys(country);
            BillingCityField.SendKeys(city);
            BillingZipCodeField.SendKeys(zipCode);
        }

        public void FillOutVatId(string vatId)
        {
            BillingVatIdField.SendKeys(vatId);
        }

        public void FillOutState(string state)
        {
            BillingSelectStateDropdown.SendKeys(state + Keys.Enter);
        }

        public void FillOutGST(string gst)
        {
            BillingGSTField.SendKeys(gst);
        }

        public void FillOutLicenseHolderInformation(
            string firstName,
            string lastName,
            string email,
            string company,
            string address,
            string country,
            string city,
            string zipCode)
        {
            if (!LicenseHolderCheckBox.Selected)
            {
                // clear fields if has any info
                LicenseHolderFirstNameField.Clear();
                LicenseHolderLastNameField.Clear();
                LicenseHolderEmailField.Clear();
                LicenseHolderCompanyField.Clear();
                LicenseHolderAddressField.Clear();
                LicenseHolderSelectCountryDropdown.Clear();
                BillingCityField.Clear();
                BillingZipCodeField.Clear();

                // fill out new info
                LicenseHolderFirstNameField.SendKeys(firstName);
                LicenseHolderLastNameField.SendKeys(lastName);
                LicenseHolderEmailField.SendKeys(email);
                LicenseHolderCompanyField.SendKeys(company);
                LicenseHolderAddressField.SendKeys(address);
                LicenseHolderSelectCountryDropdown.SendKeys(country);
                BillingCityField.SendKeys(city);
                BillingZipCodeField.SendKeys(zipCode);
            }
        }

        public void UncheckLicenseHolderCheckBox()
        {
            if (LicenseHolderCheckBox.Selected == true)
            {
                LicenseHolderCheckBox.Click();
            }

        }

        public bool CheckStateFieldIsDisplayed()
        {
            if (DoesElementExist(driver, By.Id("siState")) || DoesElementExist(driver, By.Id("biState")))
            { 
                return true; 
            }
            else 
            { 
                return false; 
            }
        }

        public bool CheckVATFieldIsDisplayed()
        {
            if (DoesElementExist(driver, By.Id("biCountryTaxIdentificationNumber")) 
                || DoesElementExist(driver, By.Id("siCountryTaxIdentificationNumber")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckGSTFieldIsDisplayed()
        {
            if (DoesElementExist(driver, By.Id("biGST")) || DoesElementExist(driver, By.Id("siGST")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckErrorMessageIsDisplayed()
        {
            if (DoesElementExist(driver, By.Id("error-message")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetErrorMessage()
        {
            return ErrorMessageLabel.Text;
        }

        public bool CheckEmailValidation(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            bool isValid = Regex.IsMatch(email, emailPattern);

            return isValid;
        }

        public void PressContinueButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("e2e-continue"))).Click();
        }


        public async Task PressBackButton()
        {
            BackButton.Click();
        }
    }
}
