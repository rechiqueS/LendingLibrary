using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }
}
