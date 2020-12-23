using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
    class AllProductsPage
    {

        public IWebDriver driver;


        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;


        }

        private IWebElement createbutton => driver.FindElement(By.XPath("//a[text()=\"Create new\"]"));


        public void CreateButton()
        {
            new Actions(driver).Click().Click(createbutton).Build().Perform();

        }


        public void OpenProduct(string product)
        {

            driver.FindElement(By.XPath($"((//*[text()=\"{product}\"]/following::*)[9]/a)")).Click();

        }


        public void Productdelete(string product)
        {
            IWebElement removebutton = driver.FindElement(By.XPath($"(//*[text()=\"{product}\"]/following::*)[12]"));
            new Actions(driver).Click().Click(removebutton).Build().Perform();
            driver.SwitchTo().Alert().Accept();

        }


    }

    
}
