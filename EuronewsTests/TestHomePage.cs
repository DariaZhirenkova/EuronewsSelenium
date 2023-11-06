using EuronewsSelenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Linq;

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
            HomePage homePage = new HomePage(_driver);// ����� ������ �������� 
            _agreeWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            IWebElement agree = _driver.FindElement(By.Id("didomi-notice-agree-button"));
            agree.Click();
            _agreeWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));

        }

        [TestMethod]
        [DynamicData(nameof(MyDataSource), DynamicDataSourceType.Method)]
       
        public void HomePageTest(Keywords key)
        {
            HomePage homePage = new HomePage(_driver);
                       
            Assert.IsTrue(homePage.CheckPage(key));
        }

        [TestMethod]

        public void SearchPageTestPossitive()
        {
            EuronewsSearchPage searchPage = new EuronewsSearchPage(_driver);
            var results =  searchPage.GetStartSearch("football");

            var filteredResults = results.Where(x => x.Contains("football")|| x.Contains("������")).ToList();

            Assert.IsTrue(filteredResults.Count >= results.Count/2);
        }

      /*  [TestMethod]

        public void SearchPageTestNegativeText()
        {
            const string SEARCH = "vdjvbdhvbfh";
            EuronewsSearchPage searchPage = new EuronewsSearchPage(_driver);
            var results = searchPage.GetStartSearch(SEARCH);
                    

            var searchResults = _driver.FindElement(By.XPath("//p[contains(@class,'c-block-listing__results')]"));

            //Assert.IsTrue(results[0].Contains("�������� 0"));

            //Assert.IsTrue(searchResults.Text == $"�������� 0 ���������� ��� {SEARCH}");

        }*/

        [TestMethod]
        public void SearchPageTestNegativeCount()
        {
            EuronewsSearchPage searchPage = new EuronewsSearchPage(_driver);
            var results = searchPage.GetStartSearch("vdjvbdhvbfh");

            Assert.IsTrue(results.Count == 0);

        }


        public static IEnumerable<object[]> MyDataSource()
        {
            return new List<object[]>
        {
            new object[] { new Keywords("My Europe", "�����", "europe") },
            new object[] { new Keywords("���", "����������", "intern") },
            new object[] { new Keywords("Business", "business", "business") },
            new object[] { new Keywords("�����", "�����", "sport") },
            new object[] { new Keywords("Green", "�����������", "green") },
            new object[] { new Keywords("Next", "next", "next") },
            new object[] { new Keywords("�����������", "�����������", "travel") },
            new object[] { new Keywords("��������", "culture", "culture") },
            new object[] { new Keywords("�����", "�����", "video") },
         
        };
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            // �������� � ������������ �������� ���-�������� �����
            _driver.Quit();
        }
    }
}