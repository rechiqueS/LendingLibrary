using System;

namespace LendingLibrary.Domain
{
    public class LoanRepository
    {
        private readonly ILendingLibraryDbContext _context;

        public LoanRepository(ILendingLibraryDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public void AddLoan(string item, string person)
        {
            var loan = new Loan { BorrowerName = person, ItemDescription = item };
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }
    }
}