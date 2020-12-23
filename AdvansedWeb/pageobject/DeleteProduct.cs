using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
    class DeleteProduct
    {
        public IWebDriver driver;


        public DeleteProduct(IWebDriver driver)
        {
            this.driver = driver;
        }

        

        public void Productdelete(string product)
        {
            IWebElement removebutton = driver.FindElement(By.XPath($"(//*[text()=\"{product}\"]/following::*)[12]"));
            new Actions(driver).Click().Click(removebutton).Build().Perform();
            driver.SwitchTo().Alert().Accept();

        }
    }
}
