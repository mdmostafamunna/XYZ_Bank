using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using XYZ_Bank.BaseClass;
namespace XYZ_Bank
{
    [TestFixture]
    public class Tests : BaseTest
    {

        [Test, Order(1), Category("Smoke Testing")]
        [Author("Mostafa Munna", "mmunna@macg.com")]
        public void NavigateToTheURL()
        {
            driver.FindElement(By.XPath("//button[contains(text(),'Bank Manager Login')]")).Click();

        }

        [Test, Order(2), Category("Sanity Testing")]
        [Description("After running this test script, a customer is automatically created")]
        public void AddCustomer()
        {
            driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[1]/button[1]")).Click();
            driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/div[1]/input[1]")).SendKeys("Munna");
            driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/div[2]/input[1]")).SendKeys("Patwary");
            driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/div[3]/input[1]")).SendKeys("1208");
            driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/button[1]")).Click();
            IAlert idAlert = driver.SwitchTo().Alert();
            idAlert.Accept();
        }
        [Test, Order(3), Category("Sanity Testing")]

        public void OpenCustomer()
        {
            driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[1]/button[2]")).Click();
            IWebElement selectUserDropdownList = driver.FindElement(By.XPath(".//*[@id='userSelect']"));
            SelectElement element = new SelectElement(selectUserDropdownList);
            element.SelectByText("Munna Patwary");

            IWebElement selectCurrencyDropdownList = driver.FindElement(By.XPath(".//*[@id='currency']"));
            SelectElement element1 = new SelectElement(selectCurrencyDropdownList);
            element1.SelectByIndex(1);
            driver.FindElement(By.XPath("//button[contains(text(),'Process')]")).Click();
            IAlert idAlert = driver.SwitchTo().Alert();
            idAlert.Accept();
        }

    }
}