using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using System.Text.Encodings.Web;
using Nunit_test.PageObject;
using Nunit_test.MainPage;

namespace Nunit_test
{
    public class Tests
    {
        private IWebDriver driver;
        private Enterlogin enterlogin;
        private Product product;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();

            //enter login page object
            enterlogin = new Enterlogin(driver);
            enterlogin.InputLogin("user");
            
           
        }

        [Test]
        public void CreateProduct()  
        {
            
            
            //login
           
            //controlhomepage
            var NamePage = driver.FindElement(By.XPath("//*[text()=\"Home page\"]")).Text;
            Assert.AreEqual("Home page", NamePage);

            //createnewproduct
            IWebElement ButtunProducts = driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));
            new Actions(driver).Click().Click(ButtunProducts).Build().Perform();// actions 1

            IWebElement allProducttext = driver.FindElement(By.XPath("//h2[text()=\"All Products\"]"));
            driver.FindElement(By.XPath("//a[text()=\"Create new\"]")).Click();

            //input page object
            product = new Product(driver);
            product.InputProduct();
            

           
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click(); //save 
        

        }
        


        [Test]
        public void LookProduct()
        {
            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();
            //control
            var NameCategory = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[1]")).Text;
            var NameSupplier = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[2]")).Text;
            var NameQuantityPerUnit = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[3]")).Text;
            var NameUnitPrice = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[4]")).Text;
            var NameUnitsInStock = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[5]")).Text;
            var NameUnitsOnOrder = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[6]")).Text;
            var NameReorderLevel = driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[7]")).Text;

            Assert.Multiple(() =>
                {
                    Assert.AreEqual("Beverages", NameCategory);
                    Assert.AreEqual("104", NameReorderLevel);
                    Assert.AreEqual("Tokyo Traders", NameSupplier);
                    Assert.AreEqual("102", NameQuantityPerUnit);
                    Assert.AreEqual("100,0000", NameUnitPrice);
                    Assert.AreEqual("65", NameUnitsInStock);
                    Assert.AreEqual("103", NameUnitsOnOrder);
                });
        }
       


        [Test]
        public void DeleteProduct()
        {
           IWebElement allProducttext = driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));
            new Actions(driver).Click().Click(allProducttext).Build().Perform();// actions 2

            //delete
           IWebElement deleteclick= driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[12]"));
            new Actions(driver).Click().Click(deleteclick).Build().Perform();// actions 3
            
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