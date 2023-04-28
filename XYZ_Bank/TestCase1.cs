using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using XYZ_Bank.BaseClass;
namespace XYZ_Bank
{
    [TestFixture]
    public class Tests : BaseTest
    {
        ExtentReports extent = null;
        ExtentTest test = null;

        [OneTimeSetUp]
        public void ExtendStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\\Users\\Fin Source\\source\\repos\\XYZ_Bank\\XYZ_Bank\\Reports\Report1.html");
            extent.AttachReporter(htmlReporter);


        }

        [OneTimeTearDown]
        public void ExtendClosed()
        {
            extent.Flush();

        }

        [Test, Order(1), Category("Smoke Testing")]
        [Author("Mostafa Munna", "mmunna@macg.com")]
        public void NavigateToTheURL()
        {

            try
            {
                test = extent.CreateTest("Navigate to the URL.").Info("Test Started");
                driver.FindElement(By.XPath("//button[contains(text(),'Bank Manager Login')]")).Click();
                test.Log(Status.Info, "User can navigate to the url");
                test.Log(Status.Pass, "Successfully navigated to the url");
            }
            catch (Exception ex)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile("C:\\Users\\Fin Source\\source\\repos\\XYZ_Bank\\XYZ_Bank\\Screenshots\\Screenshot1.png", ScreenshotImageFormat.Png);
                Console.WriteLine(ex.StackTrace);
                test.Log(Status.Fail, "Failed to navigate to the url.");
                throw;
                
            }



        }

        [Test, Order(2), Category("Sanity Testing")]
        [Description("After running this test script, a customer is automatically created")]
        public void AddCustomer()
        {
            try
            {
                test = extent.CreateTest("Add Customer").Info("Test Start");
                driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[1]/button[1]")).Click();
                driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/div[1]/input[1]")).SendKeys("Munna");
                driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/div[2]/input[1]")).SendKeys("Patwary");
                driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/div[3]/input[1]")).SendKeys("1208");
                driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/form[1]/button[1]")).Click();
                IAlert idAlert = driver.SwitchTo().Alert();
                idAlert.Accept();
                test.Log(Status.Info, "Alert is handled");
                test.Log(Status.Pass, "Add Customer test cases is passed");
            }

            catch (Exception ex)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile("C:\\Users\\Fin Source\\source\\repos\\XYZ_Bank\\XYZ_Bank\\Screenshots\\Screenshot1.png", ScreenshotImageFormat.Png);
                Console.WriteLine(ex.StackTrace);
                test.Log(Status.Fail, "Add Customer Test case is failed");
                throw;
                
            }


            
        }
        [Test, Order(3), Category("Sanity Testing")]

        public void OpenCustomer()
        {
            
            try
            {
                test = extent.CreateTest("Open Customer account.").Info("Test Started");
                driver.FindElement(By.XPath("//body/div[1]/div[1]/div[2]/div[1]/div[1]/button[2]")).Click();
                IWebElement selectUserDropdownList = driver.FindElement(By.XPath(".//*[@id='userSelect']"));
                SelectElement element = new SelectElement(selectUserDropdownList);
                element.SelectByText("Munna Patwary");
                test.Log(Status.Info, "Item selected from customer dropdown");

                IWebElement selectCurrencyDropdownList = driver.FindElement(By.XPath(".//*[@id='currencyy']"));
                SelectElement element1 = new SelectElement(selectCurrencyDropdownList);
                element1.SelectByIndex(1);
                driver.FindElement(By.XPath("//button[contains(text(),'Process')]")).Click();
                IAlert idAlert = driver.SwitchTo().Alert();
                idAlert.Accept();
                test.Log(Status.Info, "Alert is handled");
                test.Log(Status.Pass, "Open Customer test case is passed");
                

            }
            catch (Exception e)
            {
                //ITakesScreenshot ts = driver as ITakesScreenshot;
                //Screenshot screenshot = ts.GetScreenshot();
                Screenshot  ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile("C:\\Users\\Fin Source\\source\\repos\\XYZ_Bank\\XYZ_Bank\\Screenshots\\Screenshot1.png", ScreenshotImageFormat.Png);
                Console.WriteLine(e.StackTrace);
                test.Log(Status.Fail, e.ToString());
                throw;
                
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }


        }

        static IList DataDrivenTesting()
        {
            ArrayList list = new ArrayList();

            list.Add("https://www.facebook.com");
            list.Add("https://www.youtube.com");
            list.Add("https://www.gmail.com");

            return list;
        }

    }
}