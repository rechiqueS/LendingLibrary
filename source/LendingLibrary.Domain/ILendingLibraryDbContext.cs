using System.Data.Entity;

namespace LendingLibrary.Domain
{
    public interface ILendingLibraryDbContext
    {
        IDbSet<Loan> Loans { get; set; }
        int SaveChanges();
    }
}