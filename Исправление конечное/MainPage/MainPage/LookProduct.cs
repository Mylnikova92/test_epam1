using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using OpenQA.Selenium;

namespace Nunit_test.MainPage
{
    class LookProduct
    {

        private IWebDriver driver;

        public LookProduct(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement ProductsButton => driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));
        private IWebElement NameCategory => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[1]"));
        private IWebElement NameSupplier => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[2]"));
        private IWebElement NameQuantityPerUnit => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[3]"));
        private IWebElement NameUnitPrice => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[4]"));
        private IWebElement NameUnitsInStock => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[5]"));
        private IWebElement NameUnitsOnOrder => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[6]"));
        private IWebElement NameReorderLevel => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[7]"));

        public void lookproduct()
        {
            ProductsButton.Click();
            string category = NameCategory.Text;
           string Supplier = NameSupplier.Text;
            string QuantityPerUnit =  NameQuantityPerUnit.Text;
            string UnitPrice = NameUnitPrice.Text;
            string UnitsInStock = NameUnitsInStock.Text;
           string UnitsOnOrder = NameUnitsOnOrder.Text;
          string ReorderLevel =  NameReorderLevel.Text;

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Beverages", category);
                Assert.AreEqual("104", ReorderLevel);
                Assert.AreEqual("Tokyo Traders", Supplier);
                Assert.AreEqual("102", QuantityPerUnit);
                Assert.AreEqual("100,0000", UnitPrice);
                Assert.AreEqual("65", UnitsInStock);
                Assert.AreEqual("103", UnitsOnOrder);
            });

        }


    }
}




