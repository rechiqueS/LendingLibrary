using PeanutButter.TestUtils.Entity;
using PeanutButter.Utils.Entity;

namespace LendingLibrary.Domain.Tests.Models
{
    public class LendingLibraryContextPersistenceTestFixtureBase : EntityPersistenceTestFixtureBase<LendingLibraryDbContext>
    {
        public LendingLibraryContextPersistenceTestFixtureBase()
        {
            Configure(false, connectionString => new CompositeDBMigrator(connectionString, true));
            DisableDatabaseRegeneration();
            RunBeforeFirstGettingContext(Clear);
        }

        private void Clear(LendingLibraryDbContext context)
        {
            context.Loans.Clear();
            context.SaveChangesWithErrorReporting();
        }
    }
}
