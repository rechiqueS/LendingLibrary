using System.Diagnostics.Contracts;
using System.Web.Mvc;
using LendingLibrary.Controllers;
using LendingLibrary.Models;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LendingLibrary.Tests.Controllers
{
    [TestFixture]
    public class TestHomeController
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
        public void Index_ShouldUseLendingModel()
        {
            //---------------Set up test pack-------------------
            var homeController = new HomeController();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.WithCallTo(controller => controller.Index())
                .ShouldRenderDefaultView()
                .WithModel<LendingModel>(Assert.IsNotNull);
            //---------------Test Result -----------------------
        }

        [Test]
        public void Index_GivenApostedLendingModel_ShouldRenderDefaultView()
        {
            //---------------Set up test pack-------------------
            var homeController = new HomeController();
            var lendingModel = new LendingModel();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.WithCallTo(controller => controller.Index(lendingModel))
                .ShouldRenderDefaultView()
                .WithModel(lendingModel);
            //---------------Test Result -----------------------
        }

        [Test]
        public void Index_GivenPostedLendingModel_ShouldDisplaySuccessfullyLended()
        {
            //---------------Set up test pack-------------------
            var homeController = new HomeController();
            var lendingModel = new LendingModel(); 
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.Index(lendingModel);
            //---------------Test Result -----------------------
            var message = homeController.ViewBag.Message;
            Assert.AreEqual("Successfully Lended", message);   
        }

        [Test]
        public void AddView_ShouldUseLendingItemModel()
        {
            //---------------Set up test pack-------------------
            var homeController = new HomeController();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.WithCallTo(controller => controller.AddView())
                .ShouldRenderDefaultView()
                .WithModel<LendingItemModel>(Assert.IsNotNull);
            //---------------Test Result -----------------------
        }

        [Test]
        public void AddView_GivenApostedLendingItemModel_ShouldRenderAddView()
        {
            //---------------Set up test pack-------------------
            var homeController = new HomeController();
            var lendingItemModel = new LendingItemModel();  
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.WithCallTo(controller => controller.AddView(lendingItemModel))
                .ShouldRenderDefaultView()
                .WithModel(lendingItemModel);
            //---------------Test Result -----------------------
        }

        [Test]
        public void AddView_GivenPostedLendingItemModel_ShouldDisplaySuccessfullyAdded()
        {
            //---------------Set up test pack-------------------
            var homeController = new HomeController();
            var lendingItemModel = new LendingItemModel();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.AddView(lendingItemModel);
            //---------------Test Result -----------------------
            var message = homeController.ViewBag.Message;
            Assert.AreEqual("Successfully Added", message);
        }
    }
}
