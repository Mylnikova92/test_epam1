using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Nunit_test.MainPage
{
    class Product
    {
        private IWebDriver driver;

        public Product(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductName => driver.FindElement(By.CssSelector("#ProductName.form-control"));
        private IWebElement CategoryName => driver.FindElement(By.CssSelector("#CategoryId.form-control"));
        private IWebElement SupplierId => driver.FindElement(By.CssSelector("#SupplierId.form-control"));
        private IWebElement UnitsInStock => driver.FindElement(By.CssSelector("#UnitsInStock.form-control"));
        private IWebElement UnitPrice => driver.FindElement(By.CssSelector("#UnitPrice.form-control"));
        private IWebElement SupplierName => driver.FindElement(By.CssSelector("#SupplierId.form-control"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.CssSelector("#UnitsOnOrder"));
       
        private IWebElement ReorderLevel => driver.FindElement(By.CssSelector("#ReorderLevel.form-control"));

        public void InputProduct()
        {

            ProductName.SendKeys("Product5");
           CategoryName.SendKeys("Beverages");
            SupplierId.SendKeys("Tokyo Traders");
            UnitsInStock.SendKeys("65");
            UnitPrice.SendKeys("100");
            SupplierId.SendKeys("101");
            QuantityPerUnit.SendKeys("102");
            UnitsOnOrder.SendKeys("103");
            ReorderLevel.SendKeys("104");
        }


    }
}







