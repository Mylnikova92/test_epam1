using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nunit_test.MainPage
{
    class DeleteProduct
    {
        private IWebDriver driver;

        public  DeleteProduct(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductsButton => driver.FindElement(By.XPath("(//a[text()=\"All Products\"])[2]"));
        private IWebElement deleteclick => driver.FindElement(By.XPath("(//*[text()=\"Product5\"]/following::*)[12]"));
        private IWebElement logoutbutton => driver.FindElement(By.XPath("//*[text()=\"Logout\"]"));
        private IWebElement LoginText  =>  driver.FindElement(By.XPath("//*[text()=\"Login\"]"));
        private IWebElement LoonForminput => driver.FindElement(By.CssSelector("#Name.form-control"));
        private IWebElement PAsswordForminput => driver.FindElement(By.CssSelector("#Password.form-control"));
        private IWebElement Enterbutton => driver.FindElement(By.CssSelector(".btn.btn-default"));

        public void deleteproduct()
        {
            new Actions(driver).Click().Click(ProductsButton).Build().Perform();
            new Actions(driver).Click().Click(deleteclick).Build().Perform();
            driver.SwitchTo().Alert().Accept();

            logoutbutton.Click();

            string Login = LoginText.Text;
            Assert.AreEqual("Login", Login);

            LoonForminput.SendKeys("user");
            PAsswordForminput.SendKeys("user");
            Enterbutton.Click();

        }


    }
}


