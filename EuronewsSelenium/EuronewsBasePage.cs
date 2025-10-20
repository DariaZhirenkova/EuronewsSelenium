using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace EuronewsSelenium
{
    public abstract class EuronewsBasePage
    {

        IWebDriver _webDriver;
        ILogger _logger;
        WebDriverWait _wait;
        const string NAV_ELEMENTS_XPATH = "//a[@class='c-navigation-bar__link']"; //"//div[contains(@class, 'list-item u-show-for-xlarge')]";

        public EuronewsBasePage(IWebDriver _wdriver,string url)
        {
            _webDriver = _wdriver;
            _webDriver.Url = url;
            _webDriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_wdriver, TimeSpan.FromSeconds(5));
            _logger = LoggerManager.GetLoggerInstance();
        }

        public EuronewsBasePage(IWebDriver _wdriver)
        {
            _webDriver = _wdriver;
            _webDriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_wdriver, TimeSpan.FromSeconds(5));
        }


        public IReadOnlyCollection<IWebElement> GetElementsByXPath(string xpath)
        {
            //_logger.LogMessage($"{xpath} GetElementsByXPath was found");
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath)))
                .Where(x => x.Enabled && x.Displayed).ToList();
        }

        public IWebElement GetElementByXPath(string xpath)
        {

            return _wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }

        public bool IsTitleContains(Keywords keyItem)
        {
            string title = _webDriver.Title;
            return title.ToLower().Contains(keyItem._titleName);
           // return _wait.Until(ExpectedConditions.TitleContains(perticularTitle.ToLower()));
        }


        public void ClickMenuPoint(Keywords keyItem)
        {
            var element = GetElementsByXPath(NAV_ELEMENTS_XPATH).Where(x => x.Text == keyItem._xPath).First();
            if (element == null)
            {
                _logger.LogError($"{keyItem._xPath} was not found");
            }
            else {
                _logger.LogMessage($"{keyItem._xPath} was found");
                element.Click();
            }
        }

         public void FindInputEnter(string xPath, string infoToSearch)
        {
            var searchInput = GetElementByXPath(xPath);
            searchInput.Click();
            searchInput.SendKeys(infoToSearch);
            searchInput.SendKeys(Keys.Enter);
        }

        public List<string> FindReturnList(string xPath)
        {
            var results = _webDriver.FindElements(By.XPath(xPath));
            return results.Select(x => x.Text).ToList();
        }
        public bool IsURLTrue(Keywords keyItem)
        {
            string url = _webDriver.Url;
            return url.Contains(keyItem._urlName);

        }
    }
}
