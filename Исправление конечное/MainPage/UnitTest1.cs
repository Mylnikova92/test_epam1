using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using System.Text.Encodings.Web;
using Nunit_test.PageObject;
using Nunit_test.MainPage;
using Nunit_test.businesobject;


namespace Nunit_test
{
    public class Tests
    {
        private IWebDriver driver;
        private Enterlogin enterlogin;
        private inputProduct product;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();

            //enter login page object
            enterlogin = new Enterlogin(driver);
            enterlogin.InputLogin("user");
            
           
        }

        [Test]
        public void CreateProduct()  
        {
            
            product = new inputProduct(driver);
            product.InputProduct("Product5");
           
        }
        


        [Test]
        public void LookProduct()
        {
            LookProduct look = new LookProduct(driver);
            look.lookproduct();
        }
       


        [Test]
        public void DeleteProduct()
        {
             DeleteProduct Delete = new DeleteProduct(driver);
            Delete.deleteproduct();
            
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}