using Microsoft.IdentityModel.Tokens;
using Progress_Store.Pages;

namespace Progress_Store.Tests
{
    public class ContactInfoPageTests : HomeTest, Constants
    {
        private PurchasePage purchasePage;
        private YourOrderPage yourOrderPage;
        private ContactInfoPage contactInfoPage;
        private ReviewOrderPage reviewOrderPage;

        [SetUp]
        public void Setup()
        {
            purchasePage = new PurchasePage(driver);
            yourOrderPage = new YourOrderPage(driver);
            contactInfoPage = new ContactInfoPage(driver);
            reviewOrderPage = new ReviewOrderPage(driver);
            AddProductToShoppingCart();
        }

        // success scenario 
        [TestCase(Constants.FirstName, Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, null)]
        // missing fisrst name
        [TestCase(" ", Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.RequiredFirstNameError)]
        //[TestCase(Constants.FirstName, " ", Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
        //    Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.RequiredLastNameError)]
        // missin email
        [TestCase(Constants.FirstName, Constants.LastName, "", Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.RequiredEmailError)]
        // invalid email
        [TestCase(Constants.FirstName, Constants.LastName, Constants.InvalidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.InvalidEmailError)]
        // Invalit VAT Id
        [TestCase(Constants.FirstName, Constants.LastName, Constants.InvalidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.InvalidVatIdGST, null, Constants.InvalidVatIdError)]
        // invalid GST
        [TestCase(Constants.FirstName, Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryCanada, Constants.CountryCanadaState, Constants.City, Constants.ZipCode, null, Constants.InvalidVatIdGST, Constants.InvalidGSTError)]
        // Invalid ZipCode
        [TestCase(Constants.FirstName, Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryUnitedStates, Constants.CountryUSState, Constants.City, Constants.InvalidZipCode, null, null, Constants.InvalidZipCodeError)]
        public void FillBillingContactInfoFormAndContinue(
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
            string gstId,
            string errorMessage)
        {
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

            CheckValidations(firstName, lastName, email, company, phone, address, country, state, city, zipCode, vatId, gstId, errorMessage);
            if (errorMessage == null)
            {
                ContinueToReviewOrder();
            }
        }

        // success scenario 
        [TestCase(Constants.FirstName, Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, null)]
        // missing fisrst name
        [TestCase(" ", Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.RequiredFirstNameError)]
        //[TestCase(Constants.FirstName, " ", Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
        //    Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.RequiredLastNameError)]
        // missin email
        [TestCase(Constants.FirstName, Constants.LastName, "", Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.RequiredEmailError)]
        // invalid email
        [TestCase(Constants.FirstName, Constants.LastName, Constants.InvalidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.ValidVatId, null, Constants.InvalidEmailError)]
        // Invalit VAT Id
        [TestCase(Constants.FirstName, Constants.LastName, Constants.InvalidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryBulgaria, null, Constants.City, Constants.ZipCode, Constants.InvalidVatIdGST, null, Constants.InvalidVatIdError)]
        // invalid GST
        [TestCase(Constants.FirstName, Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryCanada, Constants.CountryCanadaState, Constants.City, Constants.ZipCode, null, Constants.InvalidVatIdGST, Constants.InvalidGSTError)]
        // Invalid ZipCode
        [TestCase(Constants.FirstName, Constants.LastName, Constants.ValidEmail, Constants.Company, Constants.Phone, Constants.Address,
            Constants.CountryUnitedStates, Constants.CountryUSState, Constants.City, Constants.InvalidZipCode, null, null, Constants.InvalidZipCodeError)]
        public void FillLicenseContactInfoFormAndBackToCart(
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
            string gstId,
            string errorMessage)
        {
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

            contactInfoPage.UncheckLicenseHolderCheckBox();
            contactInfoPage.FillOutLicenseHolderInformation(
                firstName,
                lastName,
                email,
                company,
                address,
                country,
                city,
                zipCode);

            switch (country)
            {
                case Constants.CountryCanada:
                    Assert.That(contactInfoPage.CheckStateFieldIsDisplayed(), Is.True,
                        Constants.StateFieldUnavailable);
                    contactInfoPage.FillOutState(state);
                    break;
                case Constants.CountryUnitedStates:
                    Assert.That(contactInfoPage.CheckStateFieldIsDisplayed(), Is.True,
                        Constants.StateFieldUnavailable);
                    contactInfoPage.FillOutState(state);
                    break;
            }

            CheckValidations(firstName, lastName, email, company, phone, address, country, state, city, zipCode, vatId, gstId, errorMessage);
            contactInfoPage.PressBackButton();
            purchasePage.WaitElementToBeLoaded();

            Assert.That(yourOrderPage.IsPageOpen(), Is.True,
                Constants.PageNotFound);
        }

        private void CheckValidations(string firstName, string lastName, string email, string company, 
            string phone, string address, string country, string state, string city, string zipCode, 
            string vatId, string gstId, string errorMessage)
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
                Assert.That(contactInfoPage.GetErrorMessage(), Is.EqualTo(errorMessage));
            }
        }

        private void ContinueToReviewOrder()
        {
            contactInfoPage.PressContinueButton();
            reviewOrderPage.WaitContentToBeLoaded();
            Assert.That(reviewOrderPage.IsPageOpen(), Is.True,
            Constants.PageNotFound);
        }

        private void AddProductToShoppingCart()
        {
            homePage.AcceptCookies();
            homePage.NavigateToPurchasePage();

            // add  product to shopping cart
            purchasePage.AddDevCraftCompleteToCart();
            contactInfoPage.WaitElementToBeLoaded();
            yourOrderPage.CloseSignUpPopUp();
            yourOrderPage.AcceptCookies();
        }
    }

}
