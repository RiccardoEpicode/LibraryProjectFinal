using Library.Data;
using Library.Models.Entities;
using Microsoft.EntityFrameworkCore;
using FluentEmail.Core;

namespace Library.Services
{
    public class LoanService : ILoanService
    {
        private readonly AppDbContext _db;

        private readonly IFluentEmail _email;

        public LoanService(AppDbContext db, IFluentEmail email)
        {
            _db = db;
            _email = email;
        }

        public void Borrow(int bookId, string email, DateTime dueDate)
        {
            var book = _db.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == bookId);

            if (book == null || !book.IsAvailable) return;

            book.IsAvailable = false;

            var loan = new Loan
            {
                BookId = bookId,
                UserEmail = email,
                DueDate = dueDate
            };

            _db.Loans.Add(loan);
            _db.SaveChanges();

            // SEND EMAIL
            _email
                .To(email)
                .Subject($"Library Loan Confirmation: {book.Title}")
                .Body($@"
            <h2>Your Loan is Confirmed!</h2>
            <p><strong>Book:</strong> {book.Title}</p>
            <p><strong>Author:</strong> {book.Author.Name}</p>
            <p><strong>Due Date:</strong> {dueDate.ToShortDateString()}</p>
            <p>Please remember to return the book on time.</p>
        ", true)
                .Send();
        }

        public void ReturnBook(int loanId)
        {
            var loan = _db.Loans.Include(x => x.Book).FirstOrDefault(x => x.Id == loanId);
            if (loan == null) return;

            loan.Returned = true;
            loan.Book.IsAvailable = true;

            _db.SaveChanges();
        }

        public List<Loan> GetAllLoans()
        {
            return _db.Loans
                .Include(x => x.Book)
                .ThenInclude(b => b.Author)
                .Include(x => x.Book.Category)
                .ToList();
        }
    }
}
