using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nunit_test.PageObject
{
    class Enterlogin
    {
        private IWebDriver driver;

        public Enterlogin(IWebDriver driver)
        {
             this.driver = driver;
        }
        
        private IWebElement logininput => driver.FindElement(By.CssSelector("#Name.form-control"));
        private IWebElement passwordinput => driver.FindElement(By.CssSelector("#Password.form-control"));

        private IWebElement enterinput => driver.FindElement(By.CssSelector(".btn.btn-default"));

        public void InputLogin(string name)
        {
            
            logininput.SendKeys(name);
            passwordinput.SendKeys(name);
            enterinput.Click();
        }


    }
    
}
