using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
    class OpenAllProducts
    {
        public IWebDriver driver;


        public OpenAllProducts(IWebDriver driver)
        {
            this.driver = driver;

     
        }

        private IWebElement allproductsbutton => driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));


        public void ClickAllProducts()
        {
            allproductsbutton.Click();
        }





    }



}
