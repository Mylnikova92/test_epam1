using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

        
        public IWebDriver driver;
     
        private LoginPage login;
        private ProductEditingPage createproduct;
        private HomePage homepage;
        private AllProductsPage allproduct;
        private ProductEditingPage productediting;
        
       

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();

            login = new LoginPage(driver);
            login.ClickAllProducts("user", "user");
        }



        [Test, Order(1)]
        public void HomePage()
        {
            homepage = new HomePage(driver);

            string NamePageLogin = homepage.Getnamepage(); 
            Assert.AreEqual("Home page", NamePageLogin);
        }

        //createproduct
        [Test, Order(2)]
        


        public void CreateProduct()
        {
            
           
            homepage = new HomePage(driver);
            homepage.ClickAllProducts();

            allproduct = new AllProductsPage(driver);
            allproduct.CreateButton();

            productediting = new ProductEditingPage(driver);

            createproduct = new ProductEditingPage(driver);
            createproduct.InputProduct(nameProduct, "Beverages", "Tokyo Traders", "65", "100", "102", "103", "104");
            createproduct.SendButton();

            Assert.IsFalse(productediting.isElementPresent(By.XPath("//h2[text()=\"Product editing\"]")));
        }

        //lookproduct
        [Test, Order(3)]
        public void LookProduct()
        {
            homepage = new HomePage(driver);
            homepage.ClickAllProducts();

            
            

            productediting = new ProductEditingPage(driver);

            allproduct = new AllProductsPage(driver);
            allproduct.OpenProduct(nameProduct);

            string NameSupplier = productediting.GetNameSupplier();

           
            string NameCategory = productediting.GetNamecategory();

            string NameQuantityPerUnit = productediting.GetNameQuantityPerUnit();
            string NameUnitPrice = productediting.GetNameUnitPrice();
;            string NameUnitsInStock = productediting.GetNameUnitsInStock();
            string NameUnitsOnOrder = productediting.GetNameUnitsOnOrder();
            string NameReorderLevel = productediting.GetNameReorderLevel();

           

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
            productediting = new ProductEditingPage(driver);

            homepage = new HomePage(driver);
            homepage.ClickAllProducts();

            allproduct = new AllProductsPage(driver);
            allproduct.Productdelete(nameProduct);

            Thread.Sleep(1000);


           Assert.IsFalse(productediting.isElementPresent(By.XPath($"//*[text()=\"{nameProduct}\"]")));


        }
        //Logout
        [Test, Order(5)]
        public void OutLog()
        {

            homepage = new HomePage(driver);
            homepage.Exit();

            login = new LoginPage(driver);
            string LoginText = login.Namepagelogin();
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



