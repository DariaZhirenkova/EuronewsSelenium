using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace EuronewsSelenium
{
    public class HomePage:EuronewsBasePage
    {
        const string HOME_PAGE_URL = "https://ru.euronews.com";
        const string NAV_ELEMENTS_XPATH = "//div[contains(@class, 'list-item u-show-for-xlarge')]";
        
        public HomePage(IWebDriver _wdriver) : base(_wdriver, "https://ru.euronews.com")
        {
        }

        public bool CheckPage(Keywords item)
        {
            ClickMenuPoint(item);
            return IsTitleContains(item) && IsURLTrue(item);

          /*  _wait.Until(ExpectedConditions.UrlContains(item._urlName));

            string title = _webDriver.Title;

            string url = _webDriver.Url;

            _webDriver.Navigate().Back();

            return title.ToLower().Contains(item._titleName) && url.Contains(item._urlName);
          */

        }
    }
}
