namespace LendingLibrary.Domain
{
    public interface ILoanRepository
    {
        void AddLoan(string item, string person);
    }
}