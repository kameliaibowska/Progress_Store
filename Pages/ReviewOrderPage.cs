using OpenQA.Selenium.Support.UI;
using Progress_Store.Models;
using SeleniumExtras.WaitHelpers;

namespace Progress_Store.Pages
{
    public class ReviewOrderPage : ReviewOrderPageElements
    {
        public ReviewOrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void WaitContentToBeLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("container--small")));
        }


    }
}
