using NUnit.Framework;
using PeanutButter.TestUtils.Entity;
using PeanutButter.TestUtils.Generic;
using System;

namespace LendingLibrary.Domain.Tests
{
    [TestFixture]
    public class TestLoan
    {
        // created a TestCase to test Entity class Loan with properties Id & Name.
        [TestCase("Id", typeof(int))]
        [TestCase("BorrowerName", typeof(string))]
        [TestCase("ItemDescription", typeof(string))]
        public void Type_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var loan = typeof(Loan);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            loan.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }

        [Test]
        public void BorrowerName_ShouldBeRequired()
        {
            //---------------Set up test pack-------------------
            var loan = new Loan();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            loan.ShouldBeRequired(l => l.BorrowerName);
            //---------------Test Result -----------------------
        }

        [Test]
        public void ItemDescription_ShouldRequired()
        {
            //---------------Set up test pack-------------------
            var loan = new Loan();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            loan.ShouldBeRequired(l => l.ItemDescription);
            //---------------Test Result -----------------------
        }

        [Test]
        public void BorrowerName_ShouldHaveMaxLenght_100()
        {
            //---------------Set up test pack-------------------
            var loan = new Loan();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            loan.ShouldHaveMaxLengthOf(100, l => l.BorrowerName);
            //---------------Test Result -----------------------
        }

        [Test]
        public void ItemDescription_ShouldHaveMaxLength_200()
        {
            //---------------Set up test pack-------------------
            var loan = new Loan();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            loan.ShouldHaveMaxLengthOf(200, l => l.ItemDescription);
            //---------------Test Result -----------------------
        }
    }
}