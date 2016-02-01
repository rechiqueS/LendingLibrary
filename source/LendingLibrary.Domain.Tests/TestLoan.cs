using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PeanutButter.TestUtils.Generic;

namespace LendingLibrary.Domain.Tests
{
    [TestFixture]
    public class TestLoan
    {

// created a TestCase to test Entity class Loan with properties Id & Name.
        [TestCase("Id", typeof(int))]
        [TestCase("Name",typeof(string))]
        public void Type_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var loan = typeof(Loan);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            loan.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------

        }
    }
}
