using EuronewsSelenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace EuronewsTests
{
    [TestClass]
    public class TestHomePage
    {
        [TestMethod]
        [DataRow("My Europe", "европ", "europe")]
        [DataRow("Мир", "международ", "intern")]
        [DataRow("Бизнес", "эконом", "business")]
        [DataRow("Спорт", "спорт", "sport")]
        [DataRow("Green", "путешествия", "green")]
        [DataRow("Next", "next", "next")]
        [DataRow("Путешествия", "путешествия", "travel")]
        [DataRow("Культура", "culture", "culture")]
        [DataRow("Видео", "видео", "video")]

        public void TestMethod1()
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
                Assert.IsTrue(homePage.CheckPage(item));
            }

            driver.Close();
        }
    }
}