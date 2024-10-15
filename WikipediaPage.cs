using OpenQA.Selenium;

namespace WikipediaAutomation
{
    public class WikipediaPage
    {
        private readonly IWebDriver _driver;
        private const string url = "https://en.wikipedia.org/wiki/Test_automation";

        public WikipediaPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(url);
        }

        public string GetTestDrivenDevelopmentText()
        {
            var element = _driver.FindElement(By.XPath("//span[@id='Test-driven_development']/../following-sibling::p"));
            return element.Text;
        }
    }
}
