using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SeleniumExtras.WaitHelpers;

namespace EuronewsSelenium
{
    public abstract class EuronewsBasePage
    {

        IWebDriver _webDriver;
        WebDriverWait _wait;
        const string NAV_ELEMENTS_XPATH = "//div[contains(@class, 'list-item u-show-for-xlarge')]";

        public EuronewsBasePage(IWebDriver _wdriver,string url)
        {
            _webDriver = _wdriver;
            _webDriver.Url = url;
            _webDriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_wdriver, TimeSpan.FromSeconds(5));
        }

        public EuronewsBasePage(IWebDriver _wdriver)
        {
            _webDriver = _wdriver;
            _webDriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_wdriver, TimeSpan.FromSeconds(5));
        }


        public IReadOnlyCollection<IWebElement> GetElementsByXPath(string xpath)
        {

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
            element.Click();
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
