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

        public EuronewsBasePage(IWebDriver _wdriver,string url)
        {
            _webDriver = _wdriver;
            _webDriver.Url = url;
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
    }
}
