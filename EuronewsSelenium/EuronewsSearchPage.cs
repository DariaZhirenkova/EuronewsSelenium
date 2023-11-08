using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EuronewsSelenium
{
    public class EuronewsSearchPage : EuronewsBasePage
    {
        IWebDriver _webDriver;
        const string SEARCH_RESULT_TEXT_XPATH = "//div[contains(@class,'m-object__body')]";
        const string SEARCH_INPUT_HOMEPAGE = "//*[@id='search-autocomplete']/div[1]/div/input";

        public EuronewsSearchPage(IWebDriver _wDriver):base(_wDriver)
        {
        }


        public void GetToTheSearchPage(string searchingInfo)
        {
            IWebElement searchInput = _webDriver.FindElement(By.XPath(SEARCH_INPUT_HOMEPAGE));
            searchInput.Click();
            searchInput.SendKeys(searchingInfo);
            searchInput.SendKeys(Keys.Enter);

        }

        public List<string> GetStartSearch(string infoToSearch)
        {
            FindInputEnter(SEARCH_INPUT_HOMEPAGE, infoToSearch);

            Thread.Sleep(1000);

           return FindReturnList(SEARCH_RESULT_TEXT_XPATH);
          
        }
    }
}
