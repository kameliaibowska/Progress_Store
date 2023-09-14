using Progress_Store.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress_Store.StepDefinitions
{
    public class BaseSteps
    {
        protected IWebDriver driver;

        private HomePage homePage;

        public BaseSteps()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
        }

        protected void OpenHomePage()
        {
            homePage.Open();
        }

        protected void NavigateToPurchasePage()
        {
            homePage.AcceptCookies();
            homePage.NavigateToPurchasePage();
        }
    }
}
