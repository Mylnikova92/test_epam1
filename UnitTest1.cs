using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Nunit_test
{
    public class Tests
    {
        private IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()  
        {
            IWebElement element;
            
            //login
            element = driver.FindElement(By.XPath("//*[text()=\"Login\"]"));
            driver.FindElement(By.CssSelector("#Name.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector("#Password.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            //controlhomepage
            var NamePage = driver.FindElement(By.XPath("//*[text()=\"Home page\"]")).Text;
            Assert.AreEqual("Home page", NamePage);

            //createnewproduct
            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();
            element = driver.FindElement(By.XPath("//h2[text()=\"All Products\"]"));
            driver.FindElement(By.XPath("//a[text()=\"Create new\"]")).Click();

            //input
            driver.FindElement(By.CssSelector("#ProductName.form-control")).SendKeys("Product5");
            driver.FindElement(By.CssSelector("#CategoryId.form-control")).SendKeys("Beverages");
            driver.FindElement(By.CssSelector("#SupplierId.form-control")).SendKeys("Tokyo Traders");
            driver.FindElement(By.CssSelector("#UnitsInStock.form-control")).SendKeys("65");
            driver.FindElement(By.CssSelector("#UnitPrice.form-control")).SendKeys("100");
            driver.FindElement(By.CssSelector("#SupplierId.form-control")).SendKeys("101");
            driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control")).SendKeys("102");
            driver.FindElement(By.CssSelector("#UnitsOnOrder")).SendKeys("103");
            driver.FindElement(By.CssSelector("#ReorderLevel.form-control")).SendKeys("104");
           
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            //control
          var NameCategory = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[1]")).Text;
            Assert.AreEqual("Beverages", NameCategory);

          var NameSupplier = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[2]")).Text;
            Assert.AreEqual("Tokyo Traders", NameSupplier);

          var NameQuantityPerUnit = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[3]")).Text;
            Assert.AreEqual("102", NameQuantityPerUnit);

          var NameUnitPrice = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[4]")).Text;
            Assert.AreEqual("100,0000", NameUnitPrice);

          var NameUnitsInStock = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[5]")).Text;
            Assert.AreEqual("65", NameUnitsInStock);

          var NameUnitsOnOrder = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[6]")).Text;
            Assert.AreEqual("103", NameUnitsOnOrder);

          var NameReorderLevel = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[7]")).Text;
            Assert.AreEqual("104", NameReorderLevel);

            //delete
            driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[12]")).Click();
            // wait.Timeout = TimeSpan.FromSeconds(5);
            //Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.XPath("//*[text()=\"Logout\"]")).Click();

            var NamePage2 = driver.FindElement(By.XPath("//*[text()=\"Login\"]")).Text;
            Assert.AreEqual("Login", NamePage2);

            driver.FindElement(By.CssSelector("#Name.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector("#Password.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

        }


        //[Test]
        //public void Test2()
        //{

            //IWebElement element;
            

        //}


        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}