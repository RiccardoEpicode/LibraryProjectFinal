using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IBookService _bookService;

        public LoanController(ILoanService loanService, IBookService bookService)
        {
            _loanService = loanService;
            _bookService = bookService;
        }

        public IActionResult Borrow(int id)
        {
            var book = _bookService.GetById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Borrow(int bookId, string email, DateTime dueDate)
        {
            _loanService.Borrow(bookId, email, dueDate);
            return RedirectToAction("Index", "Book");
        }

        public IActionResult AllLoans()
        {
            return View(_loanService.GetAllLoans());
        }

        public IActionResult ReturnBook(int id)
        {
            _loanService.ReturnBook(id);
            return RedirectToAction("AllLoans");
        }
    }
}
