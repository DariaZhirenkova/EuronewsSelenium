using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EuronewsSelenium
{
    public class EuronewsSearchPage
    {
        IWebDriver _webDriver;
        //const string SEARCH_PAGE_URL = $"https://ru.euronews.com/search?query=";
        const string XPATH_BOX = "//*[@id='listing-search-autocomplete']/div[1]/div/input";
        //const string SEARCH_BUTTON = "//*[@id='listing-search-autocomplete']/button";
        const string SEARCH_RESULT_TEXT_XPATH = "//div[contains(@class,'m-object__body')]";
        const string SEARCH_INPUT_HOMEPAGE = "//*[@id='search-autocomplete']/div[1]/div/input";

        public EuronewsSearchPage(IWebDriver _wDriver)
        {
            _webDriver = _wDriver;
           // _webDriver.Url = SEARCH_PAGE_URL;
            _webDriver.Manage().Window.Maximize();
        }


        public void GetToTheSearchPage(string searchingInfo)
        {
            IWebElement searchInput = _webDriver.FindElement(By.XPath(SEARCH_INPUT_HOMEPAGE));
            searchInput.Click();
            searchInput.SendKeys(searchingInfo);
            searchInput.SendKeys(Keys.Enter);

        }

        public List<string> GetStartSearch(string infoToSaerch)
        {
            /* IWebElement searchBox = _webDriver.FindElement(By.XPath(XPATH_BOX));
             searchBox.SendKeys(infoToSaerch);
             //searchBox.Submit();
             searchBox.SendKeys(Keys.Enter);//рботает только enter
            */
            IWebElement searchInput = _webDriver.FindElement(By.XPath(SEARCH_INPUT_HOMEPAGE));
            searchInput.Click();
            searchInput.SendKeys(infoToSaerch);
            searchInput.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
            var searchResults = _webDriver.FindElements(By.XPath(SEARCH_RESULT_TEXT_XPATH));

            return searchResults.Select(x => x.Text).ToList();
          

            /*var searchButton = _webDriver.FindElement(By.XPath(SEARCH_BUTTON));
            searchButton.Click(); не работате нажатие кнопки поиска
            */
        }
    }
}
