using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.Domain
{
    public interface ILendingLibraryDbContext
    {
        IDbSet<Loan> Loans { get; set; }
    }

    public class LendingLibraryDbContext : DbContext, ILendingLibraryDbContext
    {
        public IDbSet<Loan> Loans { get; set; }

        public LendingLibraryDbContext(DbConnection connection) : base(connection, true)
        {
        }

        static LendingLibraryDbContext()
        {
            Database.SetInitializer<LendingLibraryDbContext>(null);
        }
    }
}