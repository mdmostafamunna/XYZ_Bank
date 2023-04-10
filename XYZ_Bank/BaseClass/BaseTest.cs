using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ_Bank.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
           driver = new ChromeDriver();
           driver.Manage().Window.Maximize();

           driver.Url = "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login";
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }

    }
}
