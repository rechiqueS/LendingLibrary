using LendingLibrary.Models;
using NUnit.Framework;

namespace LendingLibrary.Tests.Models
{
    [TestFixture]
    public class TestLendingModel
    {
        [Test]
        public void LendingModel_ShouldHaveAnItemDescriptionProperty()
        {
            //---------------Set up test pack-------------------
            var lendingModel = new LendingModel();
            const string BluePen = "Blue pen";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            lendingModel.ItemDescription = BluePen;
            //---------------Test Result -----------------------
            Assert.AreEqual(BluePen, lendingModel.ItemDescription);
        }

        [Test]
        public void LendingModel_ShouldHaveBorrowerNameProperty()
        {
            //---------------Set up test pack-------------------
            var lendingModel = new LendingModel();
            const string Jack = "Jack";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            lendingModel.BorrowerName = Jack;
            //---------------Test Result -----------------------
            Assert.AreEqual(Jack, lendingModel.BorrowerName);
        }
    }
}
