using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
    class Logout
    {

        private IWebDriver driver;


        public Logout(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement nameoutbutton => driver.FindElement(By.XPath("//*[text()=\"Logout\"]"));

        public void Exit()
        {
            nameoutbutton.Click();
        }


    }
}



