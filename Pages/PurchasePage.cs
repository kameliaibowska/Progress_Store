﻿using Progress_Store.Models;

namespace Progress_Store.Pages
{
    public class PurchasePage : PurchasePageElements
    {
        public PurchasePage(IWebDriver driver) : base(driver)
        {
        }

        public async Task AddDevCraftCompleteToCartAsync()
        {
            await Task.Run(() =>
            {
                DevCraftCompleteBuyNowButton.Click();
            });
        }
    }
}