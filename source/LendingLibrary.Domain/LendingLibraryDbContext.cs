using System.Data.Common;
using System.Data.Entity;

namespace LendingLibrary.Domain
{
    public class LendingLibraryDbContext : DbContext, ILendingLibraryDbContext
    {
        public IDbSet<Loan> Loans { get; set; }

        public LendingLibraryDbContext(string connectionString) : base(connectionString)
        {
            Database.CreateIfNotExists();
        }

        public LendingLibraryDbContext(DbConnection connection) : base(connection, true)
        {
        }

        static LendingLibraryDbContext()
        {
            Database.SetInitializer<LendingLibraryDbContext>(null);
        }
    }
}