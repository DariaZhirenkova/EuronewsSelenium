using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EuronewsSelenium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait agreeWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            HomePage homePage = new HomePage(driver);
            var key = new List<Keywords> { new Keywords("My Europe", "европ", "europe"),
                                           new Keywords("Мир", "международ", "intern"),
                                           new Keywords("Бизнес", "эконом", "business"),
                                           new Keywords("Спорт", "спорт", "sport"),
                                           new Keywords("Green", "путешествия", "green"),
                                           new Keywords("Next", "next", "next"),
                                           new Keywords("Путешествия", "путешествия", "travel"),
                                           new Keywords("Культура", "culture", "culture"),
                                           new Keywords("Видео", "видео", "video")
            };
            List<string> res = new List<string>();

            IWebElement agree = driver.FindElement(By.Id("didomi-notice-agree-button"));
            agree.Click();
            agreeWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));

            foreach (var item in key)
            {               
                res.Add($"Result for {item._titleName} is: {homePage.CheckPage(item).ToString()}");
            }
          /*  bool weather = homePage.CheckPage("Погода", "погода", "weather");
            bool justIn = homePage.CheckPage("Just In", "just", "just-in");
            bool last = homePage.CheckPage("//a[@title = 'Выпуск новостей']", "послед", "bulletin");
            bool live = homePage.CheckPage("//a[@class = 'c-menu-icons--live']", "live", "live");
          */

            driver.Close();
        }
    }
}