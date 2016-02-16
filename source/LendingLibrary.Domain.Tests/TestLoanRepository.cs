using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace LendingLibrary.Domain.Tests
{
    [TestFixture]
    public class TestLoanRepository
    {
        [Test]
        public void Construct_GivenNullContext_ShouldThrowError()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => new LoanRepository(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("context", ex.ParamName);

        }
    }
}
