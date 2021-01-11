using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using WebApplication1.Controllers;
using NLog;
using WebApplication1.Models;
namespace Webapplication1.Tests
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void login()
        {
            //Arrange
            AdminController controller = new AdminController();
            controller.ModelState.AddModelError("","dummy error")

            //Act
            ViewResult result = controller.login() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Register()
        {
            //Arrange
            AdminController controller = new AdminController();

            //Act
            ViewResult result = controller.RegistrationForm() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }  
        [TestMethod]
        public void Home()
        {
            //Arrange
            HomeeController controller = new HomeeController();

            //Act
            //RedirectToRouteResult result = controller.Home() as RedirectToRouteResult;
            ViewResult result = controller.Home() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        } 

    }

}
