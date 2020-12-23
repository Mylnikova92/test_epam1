using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAdvansed.pageobject;

namespace WebDriver_Basic
{

    public class Tests
    {
              
        public string nameProduct = "men";

        private OpenAllProducts openAllProduct;
        public IWebDriver driver;
        private Login login;
        private CreateProduct createproduct;
        private DeleteProduct delete;
        private Logout exit;
        private Objects objects;

       

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();

            login = new Login(driver);
            login.ClickAllProducts("user", "user");
        }



        [Test, Order(1)]
        public void Login()
        {

            string NamePageLogin = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Home page", NamePageLogin);
        }

        //createproduct
        [Test, Order(2)]
        


        public void CreateProduct()
        {
            objects = new Objects(driver);

            openAllProduct = new OpenAllProducts(driver);
            openAllProduct.ClickAllProducts();

            createproduct = new CreateProduct(driver);
            createproduct.InputProduct(nameProduct, "Beverages", "Tokyo Traders", "65", "100", "102", "103", "104");


            Assert.IsFalse(objects.isElementPresent(By.XPath("//h2[text()=\"Product editing\"]")));
        }

        //lookproduct
        [Test, Order(3)]
        public void LookProduct()
        {
            openAllProduct = new OpenAllProducts(driver);
            openAllProduct.ClickAllProducts();

            objects = new Objects(driver);
            objects.OpenProduct(nameProduct);


            string NameSupplier = objects.NameSupplier();

           
            string NameCategory = objects.Namecategory();

            string NameQuantityPerUnit = objects.NameQuantityPerUnit();
            string NameUnitPrice = objects.NameUnitPrice();
;            string NameUnitsInStock = objects.NameUnitsInStock();
            string NameUnitsOnOrder = objects.NameUnitsOnOrder();
            string NameReorderLevel = objects.NameReorderLevel();

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
        [Test, Order(4)]
        public void DeleteProduct()
        {
            objects = new Objects(driver);
            openAllProduct = new OpenAllProducts(driver);
            openAllProduct.ClickAllProducts();

            delete = new DeleteProduct(driver);
            delete.Productdelete(nameProduct);

           Assert.IsFalse(objects.isElementPresent(By.XPath($"//*[text()=\"{nameProduct}\"]")));


        }
        //Logout
        [Test, Order(5)]
        public void OutLog()
        {
            exit = new Logout(driver);
            exit.Exit();
            objects = new Objects(driver);
            string LoginText = objects.Namepagelogin();
            Assert.AreEqual("Login", LoginText);




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



