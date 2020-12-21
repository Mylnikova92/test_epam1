using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
   class CreateProduct
    {
        private IWebDriver driver;

        
        public CreateProduct(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement createbutton => driver.FindElement(By.XPath("//a[text()=\"Create new\"]"));
        private IWebElement nameProduct => driver.FindElement(By.CssSelector("#ProductName.form-control"));
        private IWebElement nameCategoryId => driver.FindElement(By.CssSelector("#CategoryId.form-control"));
        private IWebElement nameSupplierId => driver.FindElement(By.CssSelector("#SupplierId.form-control"));
        private IWebElement nameUnitsInStock => driver.FindElement(By.CssSelector("#UnitsInStock.form-control"));
        private IWebElement nameUnitPrice => driver.FindElement(By.CssSelector("#UnitPrice.form-control"));
       
        private IWebElement nameQuantityPerUnit => driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control"));
        private IWebElement nameUnitsOnOrde => driver.FindElement(By.CssSelector("#UnitsOnOrder"));
        private IWebElement nameReorderLevel => driver.FindElement(By.CssSelector("#ReorderLevel.form-control"));
        private IWebElement namesavebutton => driver.FindElement(By.CssSelector(".btn.btn-default"));

        public void InputProduct(string product)
        {

            new Actions(driver).Click().Click(createbutton).Build().Perform(); 

            nameProduct.SendKeys(product);

            new Actions(driver).Click().Click(nameCategoryId).Build().Perform();
            new Actions(driver).SendKeys(nameCategoryId, "Beverages").Build().Perform();

           
            nameSupplierId.SendKeys("Tokyo Traders");
            nameUnitsInStock.SendKeys("65");
            nameUnitPrice.SendKeys("100");
            nameQuantityPerUnit.SendKeys("102");
            nameUnitsOnOrde.SendKeys("103");
            nameReorderLevel.SendKeys("104");

            new Actions(driver).Click().Click(namesavebutton).Build().Perform();


        }
    }
}

