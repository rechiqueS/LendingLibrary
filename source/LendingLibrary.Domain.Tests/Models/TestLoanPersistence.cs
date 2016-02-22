using NUnit.Framework;

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
