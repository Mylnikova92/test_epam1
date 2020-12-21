using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumAdvansed.pageobject;

namespace WebDriver_Basic
{
    public class Tests
    {

        private IWebDriver driver;
        private Login login;
        private CreateProduct createproduct;
        private DeleteProduct delete;
        private Logout exit;
        private string nameProduct = "Product11";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();

            login = new Login(driver);
            login.ClickAllProducts("user", "user");
        }






        //createproduct
        [Test, Order(1)]
        public void CreateProduct()
        {

            createproduct = new CreateProduct(driver);
            createproduct.InputProduct(nameProduct);
        }

        //lookproduct
        [Test, Order(2)]
        public void LookProduct()
        {
            
            string NameCategory = driver.FindElement(By.XPath($"(//*[text()=\"{nameProduct}\"]/following::*)[1]")).Text;
            string NameSupplier = driver.FindElement(By.XPath($"(//*[text()=\"{nameProduct}\"]/following::*)[2]")).Text;
            string NameQuantityPerUnit = driver.FindElement(By.XPath($"(//*[text()=\"{nameProduct}\"]/following::*)[3]")).Text;
            string NameUnitPrice = driver.FindElement(By.XPath($"(//*[text()=\"{nameProduct}\"]/following::*)[4]")).Text;
            string NameUnitsInStock = driver.FindElement(By.XPath($"(//*[text()=\"{nameProduct}\"]/following::*)[5]")).Text;
            string NameUnitsOnOrder = driver.FindElement(By.XPath($"(//*[text()=\"{nameProduct}\"]/following::*)[6]")).Text;
            string NameReorderLevel = driver.FindElement(By.XPath($"(//*[text()=\"{nameProduct}\"]/following::*)[7]")).Text;

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Beverages", NameCategory);
                Assert.AreEqual("104", NameReorderLevel);
                Assert.AreEqual("Tokyo Traders", NameSupplier);
                Assert.AreEqual("102", NameQuantityPerUnit);
                Assert.AreEqual("100,0000", NameUnitPrice);
                Assert.AreEqual("65", NameUnitsInStock);
                Assert.AreEqual("103", NameUnitsOnOrder);
            });




        }
        //DeleteProduct
        [Test, Order(3)]
        public void DeleteProduct()
        {
            delete = new DeleteProduct(driver);
            delete.Productdelete(nameProduct);
           

        }
        //Logout
        [Test, Order(4)]
        public void OutLog()
        {
            exit = new Logout(driver);
            exit.Exit();

            string LoginText = driver.FindElement(By.XPath("//*[text()=\"Login\"]")).Text;
            Assert.AreEqual("Login", LoginText);

            login = new Login(driver);
            login.ClickAllProducts("user", "user");



        }






        //outChrome
        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }






    }



}



