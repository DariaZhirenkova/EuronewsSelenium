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
        [DataRow("My Europe", "�����", "europe")]
        [DataRow("���", "����������", "intern")]
        [DataRow("������", "������", "business")]
        [DataRow("�����", "�����", "sport")]
        [DataRow("Green", "�����������", "green")]
        [DataRow("Next", "next", "next")]
        [DataRow("�����������", "�����������", "travel")]
        [DataRow("��������", "culture", "culture")]
        [DataRow("�����", "�����", "video")]

        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait agreeWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            HomePage homePage = new HomePage(driver);
            var key = new List<Keywords> { new Keywords("My Europe", "�����", "europe"),
                                           new Keywords("���", "����������", "intern"),
                                           new Keywords("������", "������", "business"),
                                           new Keywords("�����", "�����", "sport"),
                                           new Keywords("Green", "�����������", "green"),
                                           new Keywords("Next", "next", "next"),
                                           new Keywords("�����������", "�����������", "travel"),
                                           new Keywords("��������", "culture", "culture"),
                                           new Keywords("�����", "�����", "video")
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