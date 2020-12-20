using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Nunit_test.MainPage
{
    class inputProduct
    {
        private IWebDriver driver;

        public inputProduct(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement ButtunProducts => driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));

        private IWebElement Createbutton => driver.FindElement(By.XPath("//a[text()=\"Create new\"]"));
        private IWebElement ProductName => driver.FindElement(By.CssSelector("#ProductName.form-control"));
        private IWebElement CategoryName => driver.FindElement(By.CssSelector("#CategoryId.form-control"));
        private IWebElement SupplierId => driver.FindElement(By.CssSelector("#SupplierId.form-control"));
        private IWebElement UnitsInStock => driver.FindElement(By.CssSelector("#UnitsInStock.form-control"));
        private IWebElement UnitPrice => driver.FindElement(By.CssSelector("#UnitPrice.form-control"));
        private IWebElement SupplierName => driver.FindElement(By.CssSelector("#SupplierId.form-control"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.CssSelector("#UnitsOnOrder"));
       
        private IWebElement ReorderLevel => driver.FindElement(By.CssSelector("#ReorderLevel.form-control"));

        private IWebElement SaveButton => driver.FindElement(By.CssSelector(".btn.btn-default"));


        public void  InputProduct(string product)
        {
            var NamePage = driver.FindElement(By.XPath("//*[text()=\"Home page\"]")).Text;
            Assert.AreEqual("Home page", NamePage);

            new Actions(driver).Click().Click(ButtunProducts).Build().Perform();

            Createbutton.Click();

            ProductName.SendKeys(product);
           CategoryName.SendKeys("Beverages");
            SupplierId.SendKeys("Tokyo Traders");
            UnitsInStock.SendKeys("65");
            UnitPrice.SendKeys("100");
            SupplierId.SendKeys("101");
            QuantityPerUnit.SendKeys("102");
            UnitsOnOrder.SendKeys("103");
            ReorderLevel.SendKeys("104");

            SaveButton.Click();
        }


    }
}






//controlhomepage


//createnewproduct

// actions 1

//IWebElement allProducttext = driver.FindElement(By.XPath("//h2[text()=\"All Products\"]"));

