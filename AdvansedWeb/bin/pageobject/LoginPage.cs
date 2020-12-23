using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvansed.pageobject
{
    class LoginPage
    {
        public IWebDriver driver;


        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

       
        
        private IWebElement logininput => driver.FindElement(By.CssSelector("#Name.form-control"));
        private IWebElement passwordinput => driver.FindElement(By.CssSelector("#Password.form-control"));
        private IWebElement enterinput => driver.FindElement(By.CssSelector(".btn.btn-default"));

        public void ClickAllProducts(string login, string password)
        {
            logininput.SendKeys(login);
            passwordinput.SendKeys(password);
            enterinput.Click();

            

        }

        public string Namepagelogin()
        {
            return driver.FindElement(By.XPath("//*[text()=\"Login\"]")).Text;
        }

    }
}
