using Library.Data;
using Library.Models.Entities;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _db;

        public AuthorService(AppDbContext db)
        {
            _db = db;
        }

        public List<Author> GetAll() => _db.Authors.ToList();

        public Author? GetById(int id) => _db.Authors.Find(id);

        public void Add(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public void Update(Author author)
        {
            _db.Authors.Update(author);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var a = _db.Authors.Find(id);
            if (a != null)
            {
                _db.Authors.Remove(a);
                _db.SaveChanges();
            }
        }
    }
}
