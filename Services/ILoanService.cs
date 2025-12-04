using Library.Models.Entities;

namespace Library.Services
{
    public interface ILoanService
    {
        void Borrow(int bookId, string email, DateTime dueDate);
        void ReturnBook(int loanId);
        List<Loan> GetAllLoans();
    }
}
