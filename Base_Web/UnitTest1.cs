using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace WebDriver_Basic
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
            driver.FindElement(By.CssSelector("#Name.form-control")).SendKeys("user"); ;
            driver.FindElement(By.CssSelector("#Password.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            string NamePageLogin = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Home page", NamePageLogin);

        }






        //createproduct
        [Test, Order(1)]
        public void CreateProduct()
        {
            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();

            driver.FindElement(By.XPath("//a[text()=\"Create new\"]")).Click();

            driver.FindElement(By.CssSelector("#ProductName.form-control")).SendKeys("Product9");
            driver.FindElement(By.CssSelector("#CategoryId.form-control")).SendKeys("Beverages");
            driver.FindElement(By.CssSelector("#SupplierId.form-control")).SendKeys("Tokyo Traders");
            driver.FindElement(By.CssSelector("#UnitsInStock.form-control")).SendKeys("65");
            driver.FindElement(By.CssSelector("#UnitPrice.form-control")).SendKeys("100");
            driver.FindElement(By.CssSelector("#SupplierId.form-control")).SendKeys("101");
            driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control")).SendKeys("102");
            driver.FindElement(By.CssSelector("#UnitsOnOrder")).SendKeys("103");
            driver.FindElement(By.CssSelector("#ReorderLevel.form-control")).SendKeys("104");

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();



        }

        //lookproduct
        [Test, Order(2)]
        public void LookProduct()
        {
            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();
            string NameCategory = driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[1]")).Text;
            string NameSupplier = driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[2]")).Text;
            string NameQuantityPerUnit = driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[3]")).Text;
            string NameUnitPrice = driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[4]")).Text;
            string NameUnitsInStock = driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[5]")).Text;
            string NameUnitsOnOrder = driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[6]")).Text;
            string NameReorderLevel = driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[7]")).Text;

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
        //DeleteProduct
        [Test, Order(3)]
        public void DeleteProduct()
        {
            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();
            driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[12]")).Click();
            driver.SwitchTo().Alert().Accept();

        }
        //Logout
        [Test, Order(4)]
        public void OutLog()
        {
            driver.FindElement(By.XPath("//*[text()=\"Logout\"]")).Click();
            
            string LoginText = driver.FindElement(By.XPath("//*[text()=\"Login\"]")).Text;
            Assert.AreEqual("Login", LoginText);

            driver.FindElement(By.CssSelector("#Name.form-control")).SendKeys("user"); ;
            driver.FindElement(By.CssSelector("#Password.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
          


        }






        //outChrome
        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    
    
    
    
    
    
    }



    }






   



   