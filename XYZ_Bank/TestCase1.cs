using OpenQA.Selenium;
using XYZ_Bank.BaseClass;
namespace XYZ_Bank
{
    public class Tests : BaseTest
    {

        [Test, Order(1)]
        public void NavigateToTheURL()
        {
            driver.FindElement(By.XPath("//button[contains(text(),'Bank Manager Login')]")).Click();

        }

        [Test, Order(2)]
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
    }
}