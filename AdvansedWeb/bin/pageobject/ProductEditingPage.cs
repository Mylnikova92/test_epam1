using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumAdvansed.pageobject
{
   class ProductEditingPage
    {
        public IWebDriver driver;


        public ProductEditingPage(IWebDriver driver)
        {
            this.driver = driver;

        }

       
        private IWebElement nameProduct => driver.FindElement(By.CssSelector("#ProductName.form-control"));
        private IWebElement nameCategoryId => driver.FindElement(By.CssSelector("#CategoryId.form-control"));
        private IWebElement nameSupplierId => driver.FindElement(By.CssSelector("#SupplierId.form-control"));
        private IWebElement nameUnitsInStock => driver.FindElement(By.CssSelector("#UnitsInStock.form-control"));
        private IWebElement nameUnitPrice => driver.FindElement(By.CssSelector("#UnitPrice.form-control"));
       
        private IWebElement nameQuantityPerUnit => driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control"));
        private IWebElement nameUnitsOnOrde => driver.FindElement(By.CssSelector("#UnitsOnOrder"));
        private IWebElement nameReorderLevel => driver.FindElement(By.CssSelector("#ReorderLevel.form-control"));
        private IWebElement namesavebutton => driver.FindElement(By.CssSelector(".btn.btn-default"));

        

        public void InputProduct(string product, string nameCategory, string nameSupplier, string nameUnits, string nameUnitPri, string nameQuantity, string nameUnitsOn, string nameReorder)
        {
                       

            nameProduct.SendKeys(product);
            new Actions(driver).Click().Click(nameCategoryId).Build().Perform();
            new Actions(driver).SendKeys(nameCategoryId, nameCategory).Build().Perform();
            nameSupplierId.SendKeys(nameSupplier);
            nameUnitsInStock.SendKeys(nameUnits);
            nameUnitPrice.SendKeys(nameUnitPri);
            nameQuantityPerUnit.SendKeys(nameQuantity);
            nameUnitsOnOrde.SendKeys(nameUnitsOn);
            nameReorderLevel.SendKeys(nameReorder);

            

        }

        public void SendButton()
        {
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            

        }

        public bool isElementPresent(By locator)
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


        public string GetNameSupplier()
        {
            IWebElement selectSupplier = driver.FindElement(By.CssSelector("#SupplierId.form-control"));
            SelectElement strsupplier = new SelectElement(selectSupplier);
            return strsupplier.SelectedOption.Text;

        }
        public string GetNamecategory()
        {
            IWebElement selectcategory = driver.FindElement(By.CssSelector("#CategoryId.form-control"));
            SelectElement strcategory = new SelectElement(selectcategory);
            return strcategory.SelectedOption.Text;

        }
        public string GetNameQuantityPerUnit()
        {
            return driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control")).GetAttribute("value");

        }
        public string GetNameUnitPrice()
        {
            return driver.FindElement(By.CssSelector("#UnitPrice.form-control")).GetAttribute("value");

        }
        public string GetNameUnitsInStock()
        {
            return driver.FindElement(By.CssSelector("#UnitsInStock.form-control")).GetAttribute("value");

        }
        public string GetNameUnitsOnOrder()
        {
            return driver.FindElement(By.CssSelector("#UnitsOnOrder")).GetAttribute("value");

        }
        public string GetNameReorderLevel()
        {
            return driver.FindElement(By.CssSelector("#ReorderLevel.form-control")).GetAttribute("value");


        }

       

    }
}

