using Progress_Store.Pages;

namespace Progress_Store.Tests
{
    public class HomeTest : RootTest
    {
        protected HomePage homePage;

        [SetUp]
        public new void Setup()
        {
            homePage = new HomePage(driver);
            homePage.Open();
        }
    }
}
