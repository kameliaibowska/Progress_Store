using Progress_Store.Pages;
using TechTalk.SpecFlow;
using Microsoft.IdentityModel.Tokens;
using OpenQA.Selenium.DevTools.V116.Autofill;
using OpenQA.Selenium;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace Progress_Store.StepDefinitions
{
    [Binding]
    public class ContactInfoSteps : BaseSteps
    {
        private PurchasePage purchasePage;
        private YourOrderPage yourOrderPage;
        private ContactInfoPage contactInfoPage;
        private ReviewOrderPage reviewOrderPage;

        private string firstName;
        private string lastName;
        private string email;
        private string company;
        private string phone;
        private string address;
        private string country;
        private string state;
        private string city;
        private string zipCode;
        private string vatId;
        private string gstId;


        [BeforeScenario]
        public void BeforeScenario()
        {
            purchasePage = new PurchasePage(driver);
            yourOrderPage = new YourOrderPage(driver);
            contactInfoPage = new ContactInfoPage(driver);
            reviewOrderPage = new ReviewOrderPage(driver);

            OpenHomePage();
        }

        [AfterScenario]
        public void AfterScenarioAsync()
        {
            driver.Quit();
        }

        [Given(@"I add product to cart")]
        public void GivenIAddProductToCart()
        {
            AddProductToShoppingCart();
        }

        [When(@"I fill out ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" billing information")]
        public void WhenIFillOutBillingInformation(
            string firstName,
            string lastName,
            string email,
            string company,
            string phone,
            string address,
            string country,
            string state,
            string city,
            string zipCode,
            string vatId,
            string gstId)
        {
            this.firstName = firstName; 
            this.lastName = lastName; 
            this.email = email; 
            this.company = company; 
            this.phone = phone;
            this.address = address;
            this.country = country;
            this.state = state;
            this.city = city;
            this.zipCode = zipCode;
            this.vatId = vatId;
            this.gstId = gstId;
            
            yourOrderPage.ClickContinueAsGuestButton();
            contactInfoPage.FillOutBillingInformation(
                firstName,
                lastName,
                email,
                company,
                phone,
                address,
                country,
                city,
                zipCode);
        }

        [Then(@"All fields are properly inserted")]
        public void ThenAllFieldsAreProperlyInserted()
        {
            switch (country)
            {
                case Constants.CountryBulgaria:
                    Assert.That(contactInfoPage.CheckVATFieldIsDisplayed(), Is.True,
                        Constants.VATFieldUnavailable);
                    contactInfoPage.FillOutVatId(vatId);
                    break;
                case Constants.CountryCanada:
                    Assert.That(contactInfoPage.CheckStateFieldIsDisplayed(), Is.True,
                        Constants.StateFieldUnavailable);
                    contactInfoPage.FillOutState(state);
                    Assert.That(contactInfoPage.CheckGSTFieldIsDisplayed, Is.True,
                        Constants.GSTFieldUnavailable);
                    contactInfoPage.FillOutGST(gstId);
                    break;
                case Constants.CountryUnitedStates:
                    Assert.That(contactInfoPage.CheckStateFieldIsDisplayed(), Is.True,
                    Constants.StateFieldUnavailable);
                    contactInfoPage.FillOutState(state);
                    break;
            }
            CheckValidations(firstName, lastName, email, company, phone, address, country, state, city, zipCode, vatId, gstId);
        }

        [Then(@"I can continue to review order")]
        public void ThenIContinueToReviewOrder()
        {
            contactInfoPage.PressContinueButton();
            reviewOrderPage.WaitContentToBeLoaded();
            Assert.That(reviewOrderPage.IsPageOpen(), Is.True, Constants.PageNotFound);
        }

        private void AddProductToShoppingCart()
        {
            NavigateToPurchasePage();

            // add  product to shopping cart
            purchasePage.AddDevCraftCompleteToCart();
            contactInfoPage.WaitElementToBeLoaded();
            yourOrderPage.CloseSignUpPopUp();
            yourOrderPage.AcceptCookies();
        }

        private void CheckValidations(string firstName, string lastName, string email, string company,
            string phone, string address, string country, string state, string city, string zipCode,
            string vatId, string gstId)
        {
            if (firstName.IsNullOrEmpty() || lastName.IsNullOrEmpty() || email.IsNullOrEmpty()
                || !contactInfoPage.CheckEmailValidation(email) || company.IsNullOrEmpty()
                || phone.IsNullOrEmpty() || address.IsNullOrEmpty() || country.IsNullOrEmpty()
                || city.IsNullOrEmpty() || zipCode.IsNullOrEmpty() ||
                (contactInfoPage.CheckStateFieldIsDisplayed() && state.IsNullOrEmpty()) ||
                (contactInfoPage.CheckVATFieldIsDisplayed() && vatId.IsNullOrEmpty()) ||
                (contactInfoPage.CheckGSTFieldIsDisplayed() && gstId.IsNullOrEmpty()))
            {
                Assert.That(contactInfoPage.CheckErrorMessageIsDisplayed, Is.False);
                Assert.That(contactInfoPage.GetErrorMessage(), Is.EqualTo(""));
            }
        }
    }
}
