using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PeanutButter.TestUtils.Generic;

namespace LendingLibrary.Domain.Tests.Models
{
    [TestFixture]
    public class TestLoanPersistence: LendingLibraryContextPersistenceTestFixtureBase
    {
        [Test]
        public void Loan_ShouldBeAbleToPersistAndRecall()
        {
            ShouldBeAbleToPersist<LoanBuilder, Loan>(
                ctx => ctx.Loans);
        }
    }
}
