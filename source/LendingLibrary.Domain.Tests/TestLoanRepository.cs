using LendingLibrary.DbMigrations;
using NUnit.Framework;
using PeanutButter.TestUtils.Entity;
using PeanutButter.Utils.Entity;
using System;
using System.Linq;

namespace LendingLibrary.Domain.Tests
{
    [TestFixture]
    public class TestLoanRepository : EntityPersistenceTestFixtureBase<LendingLibraryDbContext>
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Configure(false, connectionString => new MigrationsRunner(connectionString, Console.WriteLine));
            RunBeforeFirstGettingContext(Clear);
            DisableDatabaseRegeneration();
        }

        private void Clear(LendingLibraryDbContext ctx)
        {
            ctx.Loans.Clear();
            ctx.SaveChangesWithErrorReporting();
        }

        [Test]
        public void AddLoan_GivenAnItemAndPerson_ShouldAddLoanToDataBase()
        {
            //---------------Set up test pack-------------------
            using (var context = GetContext())
            {
                var loanRepository = new LoanRepository(context);
                var item = "Harry Potter book";
                var person = "James";
                //---------------Assert Precondition----------------
                Assert.AreEqual(0, context.Loans.Count());
                //---------------Execute Test ----------------------
                loanRepository.AddLoan(item, person);
                //---------------Test Result -----------------------
                Assert.AreEqual(1, context.Loans.Count());
                var loan = context.Loans.FirstOrDefault();
                Assert.AreEqual(item, loan.ItemDescription);
                Assert.AreEqual(person, loan.BorrowerName);
            }
        }
    }
}