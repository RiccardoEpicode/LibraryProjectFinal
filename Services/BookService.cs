using Library.Data;
using Library.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _db;

        public BookService(AppDbContext db)
        {
            _db = db;
        }

        public List<Book> GetAll()
        {
            return _db.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToList();
        }

        public Book? GetById(int id)
        {
            return _db.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void Update(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var b = _db.Books.Find(id);
            if (b != null)
            {
                _db.Books.Remove(b);
                _db.SaveChanges();
            }
        }
    }
}
