using LendingLibrary.Controllers;
using LendingLibrary.Domain;
using LendingLibrary.Models;
using NSubstitute;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace LendingLibrary.Tests.Controllers
{
    [TestFixture]
    public class TestHomeController
    {
        [Test]
        public void Index_ShouldReturnSomething()
        {
            //---------------Set up test pack-------------------
            var loanRepository = Substitute.For<ILoanRepository>();
            var homeController = new HomeController(loanRepository);

            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = homeController.Index() as ViewResult;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_ShouldUseLendingModel()
        {
            //---------------Set up test pack-------------------
            var loanRepository = Substitute.For<ILoanRepository>();
            var homeController = new HomeController(loanRepository);
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
            var loanRepository = Substitute.For<ILoanRepository>();
            var homeController = new HomeController(loanRepository);
            var lendingModel = new LendingModel();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.WithCallTo(controller => controller.Index(lendingModel))
                .ShouldRenderDefaultView()
                .WithModel(lendingModel);
            //---------------Test Result -----------------------
        }

        [Test]
        public void Index_GivenPostedLendingLibraryModel_ShouldAddLoanToLoanRepository()
        {
            //---------------Set up test pack-------------------
            var loanRepository = Substitute.For<ILoanRepository>();
            var homeController = new HomeController(loanRepository);
            var lendingModel = new LendingModel();
            lendingModel.BorrowerName = "Kevin";
            lendingModel.ItemDescription = "Pen";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.Index(lendingModel);
            //---------------Test Result -----------------------
            loanRepository.Received().AddLoan("Pen", "Kevin");
        }

        [Test]
        public void Index_GivenPostedLendingModel_ShouldDisplaySuccessfullyLended()
        {
            //---------------Set up test pack-------------------
            var loanRepository = Substitute.For<ILoanRepository>();
            var homeController = new HomeController(loanRepository);
            var lendingModel = new LendingModel();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            homeController.Index(lendingModel);
            //---------------Test Result -----------------------
            var message = homeController.ViewBag.Message;
            Assert.AreEqual("Successfully Lended", message);
        }
    }
}