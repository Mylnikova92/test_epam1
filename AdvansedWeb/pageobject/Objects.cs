using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
    class Objects
    {
        public IWebDriver driver;


        public Objects(IWebDriver driver)
        {
            this.driver = driver;


        }

       
       



        
       
       
       
        public void OpenProduct(string product)
        {

            driver.FindElement(By.XPath($"((//*[text()=\"{product}\"]/following::*)[9]/a)")).Click();

        }

        public string NameSupplier()
        {
            IWebElement selectSupplier = driver.FindElement(By.CssSelector("#SupplierId.form-control"));
            SelectElement strsupplier = new SelectElement(selectSupplier);
            return strsupplier.SelectedOption.Text;

        }
        public string Namecategory()
        {
            IWebElement selectcategory = driver.FindElement(By.CssSelector("#CategoryId.form-control"));
            SelectElement strcategory = new SelectElement(selectcategory);
            return strcategory.SelectedOption.Text;

        }
        public string NameQuantityPerUnit()
        {
            return  driver.FindElement(By.CssSelector("#QuantityPerUnit.form-control")).GetAttribute("value");
            
        }
        public string NameUnitPrice()
        {
            return driver.FindElement(By.CssSelector("#UnitPrice.form-control")).GetAttribute("value");

        }
        public string NameUnitsInStock()
        {
            return driver.FindElement(By.CssSelector("#UnitsInStock.form-control")).GetAttribute("value");

        }
        public string NameUnitsOnOrder()
        {
            return  driver.FindElement(By.CssSelector("#UnitsOnOrder")).GetAttribute("value");

        }
        public string NameReorderLevel()
        {
            return driver.FindElement(By.CssSelector("#ReorderLevel.form-control")).GetAttribute("value");


        }

        public string Namepagelogin()
        { 
        return driver.FindElement(By.XPath("//*[text()=\"Login\"]")).Text;
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
    }
}
