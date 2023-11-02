using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace EuronewsSelenium
{
    public class HomePage
    {
        IWebDriver _webDriver;
        const string HOME_PAGE_URL = "https://ru.euronews.com";
        WebDriverWait _wait;

        public HomePage(IWebDriver _wdriver)
        {
            _webDriver = _wdriver;
            _webDriver.Url = HOME_PAGE_URL;
            _webDriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_wdriver,TimeSpan.FromSeconds(5));
        }

        public bool CheckPage(Keywords item)
        {
            var menuItem = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[contains(@class, 'list-item u-show-for-xlarge')]")))
                .Where(x => x.Enabled &&  x.Displayed && x.Text == item._xPath ).First();

            menuItem.Click();

            _wait.Until(ExpectedConditions.UrlContains(item._urlName));

            string title = _webDriver.Title;

            string url = _webDriver.Url;

            _webDriver.Navigate().Back();

            return title.ToLower().Contains(item._titleName) && url.Contains(item._urlName);

        }
    }
}
