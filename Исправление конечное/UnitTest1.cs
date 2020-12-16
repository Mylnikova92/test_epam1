using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using System.Text.Encodings.Web;
using Nunit_test.PageObject;

namespace Nunit_test
{
    public class Tests
    {
        private IWebDriver driver;
        private Enterlogin enterlogin;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();


            enterlogin = new Enterlogin(driver);
            enterlogin.InputLogin("user");
            
           
        }

        [Test]
        public void Test1()  
        {
            
            
            //login
           
            //controlhomepage
            var NamePage = driver.FindElement(By.XPath("//*[text()=\"Home page\"]")).Text;
            Assert.AreEqual("Home page", NamePage);

            //createnewproduct
            IWebElement ButtunProducts = driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));
            new Actions(driver).Click().Click(ButtunProducts).Build().Perform();// actions 1

            IWebElement element = driver.FindElement(By.XPath("//h2[text()=\"All Products\"]"));
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
           
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click(); //save 
        

        }
        


        [Test]
        public void Test2()
        {
            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();
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


        }
       


        [Test]
        public void Test3()
        {
           IWebElement element3= driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));
            new Actions(driver).Click().Click(element3).Build().Perform();// actions 2

            //delete
           IWebElement element4= driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[12]"));
            new Actions(driver).Click().Click(element4).Build().Perform();// actions 3
            
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.XPath("//*[text()=\"Logout\"]")).Click();

            var NamePage2 = driver.FindElement(By.XPath("//*[text()=\"Login\"]")).Text;
            Assert.AreEqual("Login", NamePage2);

            driver.FindElement(By.CssSelector("#Name.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector("#Password.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}