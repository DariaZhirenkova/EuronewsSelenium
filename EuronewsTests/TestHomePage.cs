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
        private static IWebDriver _driver;
        private static WebDriverWait _agreeWait;


        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _driver = new ChromeDriver();
            HomePage homePage = new HomePage(_driver);// можно ссылку добавить 
            _agreeWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            IWebElement agree = _driver.FindElement(By.Id("didomi-notice-agree-button"));
            agree.Click();
            _agreeWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));

        }

        [TestMethod]
        [DynamicData(nameof(MyDataSource), DynamicDataSourceType.Method)]
       
        public void TestMethod1(Keywords key)
        {
            HomePage homePage = new HomePage(_driver);
                       
            Assert.IsTrue(homePage.CheckPage(key));
        }
        public static IEnumerable<object[]> MyDataSource()
        {
            return new List<object[]>
        {
            new object[] { new Keywords("My Europe", "европ", "europe") },
            new object[] { new Keywords("Мир", "международ", "intern") },
            new object[] { new Keywords("Бизнес", "эконом", "business") },
            new object[] { new Keywords("Спорт", "спорт", "sport") },
            new object[] { new Keywords("Green", "путешествия", "green") },
            new object[] { new Keywords("Next", "next", "next") },
            new object[] { new Keywords("Путешествия", "путешествия", "travel") },
            new object[] { new Keywords("Культура", "culture", "culture") },
            new object[] { new Keywords("Видео", "видео", "video") },

        };
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            // Закрытие и освобождение ресурсов веб-драйвера здесь
            _driver.Quit();
        }
    }
}