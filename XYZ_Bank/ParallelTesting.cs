using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using XYZ_Bank.BaseClass;
using XYZ_Bank.Utilities;

namespace XYZ_Bank
{
    [TestFixture]
    public class ParallelTesting
    {
        IWebDriver driver;

        [Test, Category("UAT Testing"), Category("Module1")]
        public void ParallelTestingFromUtility()
        {
            var Driver = new BrowserUtility().Init(driver);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement bankBtn = Driver.FindElement(By.XPath("//button[contains(text(),'Bank Manager Login')]"));
            bankBtn.Click();
            Driver.Close();

        }



    }
}