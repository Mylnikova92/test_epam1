using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
    class HomePage
    {
        public IWebDriver driver;


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;


        }

      


        public string Getnamepage()
        {
            return driver.FindElement(By.XPath("//h2")).Text;


        }

        private IWebElement allproductsbutton => driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));


        public void ClickAllProducts()
        {
            allproductsbutton.Click();
        }

        private IWebElement nameoutbutton => driver.FindElement(By.XPath("//*[text()=\"Logout\"]"));

        public void Exit()
        {
            nameoutbutton.Click();
        }


    }
}
