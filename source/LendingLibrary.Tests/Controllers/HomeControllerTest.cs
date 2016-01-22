using System.Diagnostics.Contracts;
using System.Web.Mvc;
using LendingLibrary.Controllers;
using LendingLibrary.Models;
using NUnit.Framework;

namespace LendingLibrary.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_ShouldReturnSomething()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About_ShouldReturnDescriptionText()
        {
            //---------------Set up test pack-------------------
            var controller = new HomeController();
            var expectedDescriptionText = "Your application description page.";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = controller.About() as ViewResult;
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedDescriptionText, result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_ShouldUseLendingModel()
        {
            //---------------Set up test pack-------------------
            var homeController = new HomeController();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = homeController.Index() as ViewResult;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<LendingModel>(result.Model);
        }
        
    }
}
