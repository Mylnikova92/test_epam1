using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriver_Basic
{
    public class Tests
    {

        private static IWebDriver driver;
       

        public static Boolean IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);

            }
            catch (NoSuchElementException e)
            {
                return false;
                    }
            return true;
        
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.CssSelector("#Name.form-control")).SendKeys("user"); ;
            driver.FindElement(By.CssSelector("#Password.form-control")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            

        }






        //createproduct
        [Test, Order(1)]
        public void CreateProduct()
        {
            string NamePageLogin = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Home page", NamePageLogin);

            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();

            driver.FindElement(By.XPath("//a[text()=\"Create new\"]")).Click();

            driver.FindElement(By.CssSelector("#ProductName.form-control")).SendKeys("Product9");
            driver.FindElement(By.CssSelector("#CategoryId.form-control")).SendKeys("Beverages");
            driver.FindElement(By.CssSelector("#SupplierId.form-control")).SendKeys("Tokyo Traders");
            driver.FindElement(By.CssSelector("#UnitsInStock.form-control")).SendKeys("65");
            driver.FindElement(By.CssSelector("#UnitPrice.form-control")).SendKeys("100");
            driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control")).SendKeys("102");
            driver.FindElement(By.CssSelector("#UnitsOnOrder")).SendKeys("103");
            driver.FindElement(By.CssSelector("#ReorderLevel.form-control")).SendKeys("104");

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            Assert.IsFalse(IsElementPresent(By.XPath("//h2[text()=\"Product editing\"]")));


        }

        //lookproduct
        [Test, Order(2)]
        public void LookProduct()
        {
            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();
            driver.FindElement(By.XPath("((//*[text()=\"Product9\"]/following::*)[9]/a)")).Click();

            

            IWebElement selectSupplier = driver.FindElement(By.CssSelector("#SupplierId.form-control"));
            SelectElement strsupplier = new SelectElement(selectSupplier);
            string NameSupplier = strsupplier.SelectedOption.Text;

            IWebElement selectcategory = driver.FindElement(By.CssSelector("#CategoryId.form-control"));
            SelectElement strcategory = new SelectElement(selectcategory);
            string NameCategory = strcategory.SelectedOption.Text;

            string NameQuantityPerUnit = driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control")).GetAttribute("value");
            string NameUnitPrice = driver.FindElement(By.CssSelector("#UnitPrice.form-control")).GetAttribute("value");
            string NameUnitsInStock = driver.FindElement(By.CssSelector("#UnitsInStock.form-control")).GetAttribute("value");
            string NameUnitsOnOrder = driver.FindElement(By.CssSelector("#UnitsOnOrder")).GetAttribute("value");
            string NameReorderLevel = driver.FindElement(By.CssSelector("#ReorderLevel.form-control")).GetAttribute("value");

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

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();


        }
        //DeleteProduct
        [Test, Order(3)]
        public void DeleteProduct()
        {

            driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]")).Click();
            driver.FindElement(By.XPath("(//*[text()=\"Product9\"]/following::*)[12]")).Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            Assert.IsFalse(IsElementPresent(By.XPath("//*[text()=\"Product9\"]")));


        }

        //Logout
        [Test, Order(4)]
        public void OutLog()
        {
            driver.FindElement(By.XPath("//*[text()=\"Logout\"]")).Click();
            
            string LoginText = driver.FindElement(By.XPath("//*[text()=\"Login\"]")).Text;
            Assert.AreEqual("Login", LoginText);

                  


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






   





   



   