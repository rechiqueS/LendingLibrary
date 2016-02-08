using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeanutButter.TestUtils.Entity;
using PeanutButter.Utils.Entity;

namespace LendingLibrary.Domain.Tests.Models
{
   public class LendingLibraryContextPresistenceTestFixtureBase: EntityPersistenceTestFixtureBase<LendingLibraryDbContext>
    {
       public LendingLibraryContextPresistenceTestFixtureBase()
       {
            Configure(false, connectionString => new CompositeDBMigrator(connectionString,true));
            DisableDatabaseRegeneration();
            RunBeforeFirstGettingContext(Clear);
       }

       private void Clear(LendingLibraryDbContext obj)
       {
           obj.Loan.Clear();
            obj.SaveChangesWithErrorReporting();
       }
    }
}
