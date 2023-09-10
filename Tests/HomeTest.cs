using Progress_Store.Pages;

namespace Progress_Store.Tests
{
    public class HomeTest : RootTest
    {
        private HomePage homePage;

        [SetUp]
        public new void Setup()
        {
            homePage = new HomePage(driver);
            homePage.Open();
        }
    }
}
